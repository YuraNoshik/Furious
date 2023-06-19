using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для ClubMain.xaml
    /// </summary>
    public partial class ClubMain : Window
    {
        private static MyACR122U acr122u = new MyACR122U();
        private DispatcherTimer timer;
        private bool isAuthorized;
        public ClubMain()
        {
            InitializeComponent();
            Frame.Content = new Clients();
            lbMenuName.Text = "КЛИЕНТЫ";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Content = new Clients();
            Frame.Content = new Clients();
            lbMenuName.Text = "КЛИЕНТЫ";
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new History();
            lbMenuName.Text = "ИСТОРИЯ ПОСЕЩЕНИЙ";
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ScheduleList();
            lbMenuName.Text = "РАСПИСАНИЕ";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new MainWindow().Show();
        }
        public void frameClosing()
        {
            Frame.Content = null;
        }

        private void btnСalculation_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Sales();
            lbMenuName.Text = "ФИНАНСЫ";
        }

        private void btnTools_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Tools();
            lbMenuName.Text = "ИНСТРУМЕНТЫ";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
