using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    /// 
    public partial class EditClient : Window
    {
        private Entity.Clients _client;
        private DispatcherTimer timer;
        private static MyACR122U acr122u = new MyACR122U();
        public EditClient(Entity.Clients client)
        {
            InitializeComponent();
            _client = client;
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                var abonements = userEntity.Abonements.Select(x => x.abonementType).ToList();
                cbEditAbonements.ItemsSource = abonements;

                var abonementType = userEntity.Abonements
                    .Include(x => x.Clients)
                    .FirstOrDefault(x => x.abonementID == _client.abonementID);

                // Заполните элементы управления значениями из объекта client
                tbEditName.Text = _client.clientName;
                tbEditSurname.Text = _client.clientSurname;
                tbEditPatronymic.Text = _client.clientPatronymic;
                tbEditPhoneNumb.Text = _client.clientPhoneNumber;
                tbEditCountOfTrainings.Text = _client.clientCountOfTrainings.ToString();
                cbEditAbonements.SelectedItem = abonementType;
                tbEditUID.Text = _client.clientUID;
            }

            try
            {
                acr122u.Init(false, 50, 4, 4, 200);  // NTAG213
                acr122u.CardInserted += Acr122u_CardInserted;
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Failed to find a reader connected to the system", "No reader connected");
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Интервал времени, например, 1 секунда
            timer.Tick += Timer_Tick;
        }
        private void Acr122u_CardInserted(PCSC.ICardReader reader)
        {
            timer.Start();
            acr122u.ReadId = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {


            if (timer.IsEnabled)
            {
                tbEditUID.Text = acr122u.ReadId;
                timer.Stop();
            }

        }
        internal class MyACR122U : ACR122U
        {
            private string readId;
            public string ReadId
            {
                get
                {
                    return readId;
                }
                set
                {
                    readId = value;
                }
            }

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbEditName.Text) && !string.IsNullOrEmpty(tbEditSurname.Text) && !string.IsNullOrEmpty(tbEditPatronymic.Text) && !string.IsNullOrEmpty(tbEditPhoneNumb.Text) && !string.IsNullOrEmpty(tbEditCountOfTrainings.Text) && !string.IsNullOrEmpty(tbEditUID.Text))
            {

                using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
                {
                    var uidExisting = context.Clients.Where(x => x.clientUID == tbEditUID.Text).FirstOrDefault();
                    if (uidExisting == null)
                    {
                        // Получите экземпляр клиента из базы данных
                        var clientInDb = context.Clients.FirstOrDefault(c => c.clientID == _client.clientID);

                        if (clientInDb != null)
                        {
                            // Обновите значения свойств клиента
                            clientInDb.clientName = tbEditName.Text;
                            clientInDb.clientSurname = tbEditSurname.Text;
                            clientInDb.clientPatronymic = tbEditPatronymic.Text;
                            clientInDb.clientPhoneNumber = tbEditPhoneNumb.Text;
                            clientInDb.clientCountOfTrainings = int.Parse(tbEditCountOfTrainings.Text);
                            clientInDb.abonementID = cbEditAbonements.SelectedIndex + 1;
                            clientInDb.clientUID = tbEditUID.Text;

                            // Установите состояние объекта как измененное
                            context.Entry(clientInDb).State = EntityState.Modified;

                            // Сохраните изменения в базе данных
                            context.SaveChanges();

                            MessageBox.Show("Данные успешно изменены!");

                            // Закройте форму редактирования
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Клиент не найден в базе данных.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такой UID уже существует");
                    }

                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
        int amountOfTrainings = 0;
        private void cbEditAbonements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbEditAbonements.SelectedIndex)
            {

                case 0:
                    tbEditCountOfTrainings.Text = Convert.ToString(amountOfTrainings = 4);
                    break;

                case 1:
                    tbEditCountOfTrainings.Text = Convert.ToString(amountOfTrainings = 8);
                    break;

                case 2:
                    tbEditCountOfTrainings.Text = Convert.ToString(amountOfTrainings = 12);
                    break;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
        private void btnCheckBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
