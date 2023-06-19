using Forsaj.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public History()
        {
            InitializeComponent();

            timer.Start();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            RefreshList();
        }

        public void RefreshList()
        {
            DateTime selectedDate = dpHistory.SelectedDate ?? DateTime.MinValue;
            string searchText = tbSearchHistory.Text.Trim();

            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                var visitHistory = userEntity.VisitHistory.Include(vh => vh.Clients).ToList();

                // Фильтрация по имени, фамилии и отчеству
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    var searchTerms = searchText.ToLower().Split(' ');

                    visitHistory = visitHistory.Where(vh =>
                        searchTerms.Any(term =>
                            vh.Clients.clientName.ToLower().Contains(term) ||
                            vh.Clients.clientSurname.ToLower().Contains(term) ||
                            vh.Clients.clientPatronymic.ToLower().Contains(term)
                        )
                    ).ToList();
                }

                // Фильтрация по дате
                if (selectedDate != DateTime.MinValue)
                {
                    visitHistory = visitHistory.Where(vh => vh.visitDate == selectedDate.Date).ToList();
                }

                listHistory.ItemsSource = visitHistory;
                lbAmountVisits.Text = "Всего посещений: " + listHistory.Items.Count;
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

        private void tbSearchHistory_TextChanged(object sender, TextChangedEventArgs e)
        {

            string searchText = tbSearchHistory.Text.Trim();

            if (searchText.Length > 0)
            {
                RefreshList();
            }
        }

        private void dpHistory_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        private void picRefreshDate_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            dpHistory.SelectedDate = null;
            tbSearchHistory.Text = "";
            RefreshList();
        }
    }
}
