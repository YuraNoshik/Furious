using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using static Forsaj.Views.CheckUID;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private static MyACR122U acr122u = new MyACR122U();
        private DispatcherTimer timer;
        private bool isAuthorized;
        public AddUser()
        {
            InitializeComponent();
            using(ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
               var roles = userEntity.Roles.Select(x => x.roleName).ToList();
                cbUserRole.ItemsSource = roles;

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

            timer.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void btnUserBack_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void btnUserAdd_Click(object sender, RoutedEventArgs e)
        {
            string firstName = tbUserName.Text;
            string lastName = tbUserSurname.Text;
            string patronymic = tbUserPatronymic.Text;
            string username = tbUserLogin.Text;
            string password = tbUserPassword.Text;
            int role = cbUserRole.SelectedIndex + 1;

            Staff newUser = new Staff
            {
                staffName = firstName,
                staffSurname = lastName,
                staffPatronymic = patronymic,
                staffLogin = username,
                staffPassword = password,
                roleID = role
            };

            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                userEntity.Staff.Add(newUser);
                userEntity.SaveChanges();
            }

            MessageBox.Show("Пользователь успешно добавлен ");
            this.Close();
        }
        private void Acr122u_CardInserted(PCSC.ICardReader reader)
        {
            timer.Start();
            acr122u.ReadId = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "");
        }


        private void Timer_Tick(object sender, EventArgs e)
        {

            tbUserPassword.Text = acr122u.ReadId;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Отписка от события CardInserted при закрытии окна
            acr122u.CardInserted -= Acr122u_CardInserted;
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
}
