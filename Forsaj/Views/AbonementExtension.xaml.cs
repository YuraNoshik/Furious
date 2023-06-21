using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для AbonementExtension.xaml
    /// </summary>
    public partial class AbonementExtension : Window
    {
        private DispatcherTimer timer;
        private static MyACR122U acr122u = new MyACR122U();
        public AbonementExtension()
        {
            InitializeComponent();
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                var abonements = userEntity.Abonements.Select(x => x.abonementType).ToList();
                cbAbonements.ItemsSource = abonements;
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
        private void Timer_Tick(object sender, EventArgs e)
        {


            if (timer.IsEnabled)
            {
                tbUID.Text = acr122u.ReadId;


                using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
                {
                    var uidExisting = userEntity.Clients.Where(x => x.clientUID == tbUID.Text).FirstOrDefault();
                    int trainingMinus = 0;

                    if (uidExisting != null)
                    {
                        trainingMinus = uidExisting.clientCountOfTrainings;
                        if (trainingMinus > 0)
                        {

                            tbUID.Text = uidExisting.clientUID.ToString();
                            lbName.Text = uidExisting.clientName.ToString();
                            lbSurname.Text = uidExisting.clientSurname.ToString();
                            lbPatronymic.Text = uidExisting.clientPatronymic.ToString();
                            lbPhoneNumber.Text = uidExisting.clientPhoneNumber.ToString();
                            tbCountOfTrainings.Text = trainingMinus.ToString();


                        }
                        else
                        {
                            tbUID.Text = uidExisting.clientUID.ToString();
                            lbName.Text = uidExisting.clientName.ToString();
                            lbSurname.Text = uidExisting.clientSurname.ToString();
                            lbPatronymic.Text = uidExisting.clientPatronymic.ToString();
                            lbPhoneNumber.Text = uidExisting.clientPhoneNumber.ToString();
                            tbCountOfTrainings.Text = trainingMinus.ToString();
                            MessageBox.Show("Абонемент закончился!");
                        }

                        timer.Stop();
                    }
                    else
                    {
                        MessageBox.Show("Клиент с таким UID не найден!");
                        timer.Stop();
                    }
                }


            }

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
            {
                var client = context.Clients.FirstOrDefault(c => c.clientUID == tbUID.Text);

                if (client != null)
                {
                    client.abonementID = cbAbonements.SelectedIndex+1;
                    client.clientCountOfTrainings = Convert.ToInt16(tbCountOfTrainings.Text);

                    Entity.Sales sale = new Entity.Sales()
                    {
                        abonementID = client.abonementID,
                        clientID = client.clientID,
                        saleDate = DateTime.Now.Date,
                        saleTime = DateTime.Now.TimeOfDay
                    };

                    context.Sales.Add(sale);
                    context.SaveChanges();
                    Close();
                    MessageBox.Show("Абонемент успешно продлен!");
                }
                else
                {
                    MessageBox.Show("Клиент с таким UID не найден!");
                    timer.Stop();
                }
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
        int amountOfTrainings = 0;  
        private void cbAbonements_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (cbAbonements.SelectedIndex)
            {

                case 0:
                    tbCountOfTrainings.Text = Convert.ToString(amountOfTrainings = 4);
                    break;

                case 1:
                    tbCountOfTrainings.Text = Convert.ToString(amountOfTrainings = 8);
                    break;

                case 2:
                    tbCountOfTrainings.Text = Convert.ToString(amountOfTrainings = 12);
                    break;
            }
        }

        private void btnCheckBack_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }
    }
}
