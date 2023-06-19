using Forsaj.Entity;
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
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для Sales.xaml
    /// </summary>
    public partial class Sales : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Sales()
        {
            InitializeComponent();
            timer.Start();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        public void RefreshList()
        {
            DateTime startDate = dpStart.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = dpEnd.SelectedDate ?? DateTime.MaxValue;
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                var sales = userEntity.Sales
                    .Include("Clients")
                    .Include("Abonements")
                    .Where(sale => sale.saleDate >= startDate && sale.saleDate <= endDate)
                    .ToList();

                var listSale = sales.Select(sale => new
                {
                    FirstName = sale.Clients.clientName,
                    LastName = sale.Clients.clientSurname,
                    Patronymic = sale.Clients.clientPatronymic,
                    AbonementType = sale.Abonements.abonementType,
                    Price = sale.Abonements.abonementCost,
                    SaleDate = sale.saleDate
                }).ToList();

                listSales.ItemsSource = listSale;

                decimal totalCost = listSale.Sum(item => item.Price);

                lbAmoutCost.Text = "Общая стоимость:  " + Convert.ToString(totalCost) + " руб.";

                
                int totalCount = listSale.Count;

                lbAmoutAbonements.Text = "Проданные абонементы:  " + Convert.ToString(totalCount);
            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

        private void picRefreshDate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dpStart.SelectedDate = null;
            dpEnd.SelectedDate = null;
        }
    }
}
