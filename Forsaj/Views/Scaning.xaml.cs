using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для Scaning.xaml
    /// </summary>
    public partial class Scaning : Window
    {
        private static MyACR122U acr122u = new MyACR122U();
        private DispatcherTimer timer;
        private bool isOpen = false;
        public Scaning()
        {
            InitializeComponent();

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
            if (!timer.IsEnabled && !isOpen)
            {
                timer.Start();
                acr122u.ReadId = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "");
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
                            tbName.Text = uidExisting.clientName.ToString();
                            tbSurname.Text = uidExisting.clientSurname.ToString();
                            tbPatronymic.Text = uidExisting.clientPatronymic.ToString();

                            trainingMinus--;
                            lbCountOfTrainings.Text = trainingMinus.ToString();

                            uidExisting.clientCountOfTrainings = trainingMinus;

                            //var visitData = userEntity.VisitHistory.Where(x => x.clientID == clientID).FirstOrDefault();
                            var clients = userEntity.Clients.Where(x => x.clientUID == tbUID.Text).FirstOrDefault();


                            Entity.VisitHistory visit = new Entity.VisitHistory
                            {
                                clientID = clients.clientID,
                                visitTime = DateTime.Now.TimeOfDay,
                                visitDate = DateTime.Now.Date
                            };
                            userEntity.VisitHistory.Add(visit);

                        }
                        else
                        {
                            tbUID.Text = uidExisting.clientUID.ToString();
                            tbName.Text = uidExisting.clientName.ToString();
                            tbSurname.Text = uidExisting.clientSurname.ToString();
                            tbPatronymic.Text = uidExisting.clientPatronymic.ToString();
                            MessageBox.Show("Абонемент закончился!");
                        }


                        userEntity.SaveChanges();
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
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUID.Text))
            {
                
                    // Ваш код обработки, если uidExisting не равно null

                    using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
                    {
                        var uidExisting = userEntity.Clients.Where(x => x.clientUID == tbUID.Text).FirstOrDefault();
                        int trainingMinus = 0;
                        
                    if (uidExisting != null)
                    {
                        trainingMinus = uidExisting.clientCountOfTrainings;
                        if (trainingMinus != 0 || trainingMinus > 0)
                        {

                            tbUID.Text = uidExisting.clientUID.ToString();
                            tbName.Text = uidExisting.clientName.ToString();
                            tbSurname.Text = uidExisting.clientSurname.ToString();
                            tbPatronymic.Text = uidExisting.clientPatronymic.ToString();


                            trainingMinus--;
                            lbCountOfTrainings.Text = trainingMinus.ToString();

                            uidExisting.clientCountOfTrainings = trainingMinus;

                            //var visitData = userEntity.VisitHistory.Where(x => x.clientID == clientID).FirstOrDefault();
                            var clients = userEntity.Clients.Where(x => x.clientUID == tbUID.Text).FirstOrDefault();


                            Entity.VisitHistory visit = new Entity.VisitHistory
                            {
                                clientID = clients.clientID,
                                visitTime = DateTime.Now.TimeOfDay,
                                visitDate = DateTime.Now.Date
                            };
                            userEntity.VisitHistory.Add(visit);


                            timer.Stop();
                        }
                        else
                        {
                            MessageBox.Show("Абонемент закончился!");
                        }


                        userEntity.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Клиент с таким UID не найден!");
                        timer.Stop();
                    }
                }
                    
                
                
            }
            else
            {
                MessageBox.Show("Введите UID клиента!");
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
            isOpen = true;
            this.Close();
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


    }

}
