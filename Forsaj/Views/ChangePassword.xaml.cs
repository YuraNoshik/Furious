using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Collections.Generic;
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

namespace Forsaj.Views
{

    /// <summary>
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    /// 
    public partial class ChangePassword : Window
    {
        private static MyACR122U acr122u = new MyACR122U();

        DispatcherTimer timer = new DispatcherTimer();
        private bool isAuthorized = false;
        public ChangePassword()
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

            timer.Start();
        }

        private void Acr122u_CardInserted(PCSC.ICardReader reader)
        {
            timer.Start();
            acr122u.ReadId = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "");

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tbChangePasswordPassword.Text = acr122u.ReadId;
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

        private void btnChangePasswordBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
        }

        private void btnChangePasswordEdit_Click(object sender, RoutedEventArgs e)
        {
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                //Поиск удаляемой записи по ключевому полю
                Staff staff = userEntity.Staff.Where(c => c.staffLogin == tbChangePasswordLogin.Text).FirstOrDefault(); 
                if (staff == null)
                {
                    MessageBox.Show("Такого пользователя нет");
                    return;
                }
                else
                {  //Меняем значение полей

                    staff.staffPassword = tbChangePasswordPassword.Text;
                    
                    try
                    {
                        userEntity.SaveChanges();	//Фиксируем изменения в БД
                        MessageBox.Show("Пароль успешно изменен!");
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось изменить пароль пользователя");
                        return;
                    }
                }
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

}



