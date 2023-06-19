using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        private static MyACR122U acr122u = new MyACR122U();
        private DispatcherTimer timer;
        private Views.Clients client1;

        public AddClients()
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

        private void Timer_Tick(object sender, EventArgs e)
        {

            
            if (timer.IsEnabled)
            {
                tbUID.Text = acr122u.ReadId;
                timer.Stop();
            }

        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Отписка от события CardInserted при закрытии окна
            acr122u.CardInserted -= Acr122u_CardInserted;
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
        
        int amountOfTrainings = 0;
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                string firstName = tbName.Text;
                string lastName = tbSurname.Text;
                string patronymic = tbPatronymic.Text;
                string phoneNumber = tbPhoneNumb.Text;

                int abonementID = cbAbonements.SelectedIndex + 1;
                string Uid = tbUID.Text;

                var uidExisting = userEntity.Clients.Where(x => x.clientUID == tbUID.Text).FirstOrDefault();

                if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbSurname.Text) && !string.IsNullOrEmpty(tbPatronymic.Text) && !string.IsNullOrEmpty(tbPhoneNumb.Text) && !string.IsNullOrEmpty(tbCountOfTrainings.Text) && !string.IsNullOrEmpty(tbUID.Text))
                {
                    if (uidExisting == null)
                    {


                        Entity.Clients client = new Entity.Clients
                        {
                            clientName = firstName,
                            clientSurname = lastName,
                            clientPatronymic = patronymic,
                            clientPhoneNumber = phoneNumber,
                            clientCountOfTrainings = Convert.ToInt32(tbCountOfTrainings.Text),
                            abonementID = abonementID,
                            clientUID = Uid
                        };
                        userEntity.Clients.Add(client);

                        var finansi = userEntity.Clients.Where(x => x.abonementID == client.abonementID).FirstOrDefault();

                        Entity.Sales sale = new Entity.Sales()
                        {  
                            abonementID = client.abonementID,
                            clientID = client.clientID,
                            saleDate = DateTime.Now.Date,
                            saleTime = DateTime.Now.TimeOfDay
                        };

                        userEntity.Sales.Add(sale);


                        userEntity.Sales.Add(sale);
                        userEntity.SaveChanges();


                        MessageBox.Show("Пользователь успешно добавлен");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Такой UID уже существует");
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }
            }

            client1 = new Views.Clients();
            client1.listClients.Items.Clear();
            //client1.LoadClientsToGrid();

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

        private void btnCheckBack_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            new AbonementExtension().Show();

        }
    }

}


