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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для Tools.xaml
    /// </summary>
    public partial class Tools : Page
    {
        public Tools()
        {
            InitializeComponent();
        }
        private bool isScanFormOpen = false;
        private CheckUID check;
        private ChangePassword change;
        private AddUser addUser;


        private void btnToolsCheck_Click(object sender, RoutedEventArgs e)
        {
            if (!isScanFormOpen)
            {
                check = new CheckUID();
                check.Closed += Check_Closed; // Добавляем обработчик события Closed
                check.Show();
                isScanFormOpen = true;
            }
        }

        private void btnToolsAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (!isScanFormOpen)
            {
                addUser = new AddUser();
                addUser.Closed += AddUser_Closed; // Добавляем обработчик события Closed
                addUser.Show();
                isScanFormOpen = true;
            }
        }

        private void btnToolsChangePassword_Click(object sender, RoutedEventArgs e)
        {
            
            if (!isScanFormOpen)
            {
                change = new ChangePassword();
                change.Closed += Change_Closed; // Добавляем обработчик события Closed
                change.Show();
                isScanFormOpen = true;
            }
        }

        private void Check_Closed(object sender, EventArgs e)
        {
            isScanFormOpen = false;
        }
        private void Change_Closed(object sender, EventArgs e)
        {
            isScanFormOpen = false;
        }
        private void AddUser_Closed(object sender, EventArgs e)
        {
            isScanFormOpen = false;
        }


    }
}
