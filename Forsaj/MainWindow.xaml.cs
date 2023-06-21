using Forsaj.Entity;
using Forsaj.Views;
using Sydesoft.NfcDevice;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forsaj
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MyACR122U acr122u = new MyACR122U();
        
        DispatcherTimer timer = new DispatcherTimer();
        private bool isAuthorized = false;
        ClubMain clubMain = new ClubMain();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                acr122u.Init(false, 50, 4, 4, 200);  // NTAG213
                acr122u.CardInserted += Acr122u_CardInserted;
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Считыватель не подключен!");
            }
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += Timer_Tick;

        }
        private void Acr122u_CardInserted(PCSC.ICardReader reader)
        {
            
            if (!timer.IsEnabled && !isAuthorized)
            {
                timer.Start();
                acr122u.ReadId = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Отписка от события CardInserted при закрытии окна
            acr122u.CardInserted -= Acr122u_CardInserted;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            

                using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
                {

                    tbPassword.Password = acr122u.ReadId;
                    Staff staff;
                    staff = userEntity.Staff.Where(x => x.staffPassword == tbPassword.Password).FirstOrDefault();
                    if (staff != null)
                    {
                        tbLogin.Text = staff.staffLogin.ToString();
                        timer.Stop();
                        btnLogin_Click(btnLogin, new RoutedEventArgs());
                        isAuthorized = true;
                    }
                    else
                    {
                        timer.Stop();
                        MessageBox.Show("Неверный логин или пароль");
                        
                        tbPassword.Password = "";
                    }

                }
            

        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ClubMain clubMain = new ClubMain();
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                Staff staff;
                Roles role;
                staff = userEntity.Staff.Where(x => x.staffLogin == tbLogin.Text && x.staffPassword == tbPassword.Password).FirstOrDefault();


                if (staff != null)
                {
                    role = userEntity.Roles.Where(x => x.roleID == staff.roleID).FirstOrDefault();
                    if (role != null)
                    {
                        switch (staff.roleID)
                        {

                            default:
                                break;
                            case 1:
                                this.Close();
                                clubMain.Show();
                                MessageBox.Show($"Здравствуйте, {staff.staffName} {staff.staffPatronymic} \n Вы вошли как {role.roleName}");

                                break;
                            case 2:
                                this.Close();
                                
                                clubMain.btnTools.Visibility = Visibility.Hidden;
                                clubMain.Show();
                                MessageBox.Show($"Здравствуйте, {staff.staffName} {staff.staffPatronymic} \n Вы вошли как {role.roleName}");

                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль!");
                }

            }
            timer.Stop();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        ///////////////////////////////////////////////////////////////////
        

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
