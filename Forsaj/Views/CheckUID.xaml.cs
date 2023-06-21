using Forsaj.Entity;
using Sydesoft.NfcDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для CheckUID.xaml
    /// </summary>
    public partial class CheckUID : Window
    {
        private static MyACR122U acr122u = new MyACR122U();
        private DispatcherTimer timer;
        private bool isAuthorized;
        public CheckUID()
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
            timer.Interval = TimeSpan.FromSeconds(2); // Интервал времени, например, 1 секунда
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
