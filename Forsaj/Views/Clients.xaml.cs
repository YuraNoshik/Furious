using Forsaj.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();

            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                cbAbonement.Items.Add("Абонементы");
                var categories = userEntity.Abonements.Select(x => x.abonementType).ToList();
                cbAbonement.SelectedItem = cbAbonement.Items[0];
                foreach (var category in categories)
                {
                    cbAbonement.Items.Add(category);
                }


                var clients = userEntity.Clients.ToList();
                cbSort.Items.Add("Без сортировки");
                cbSort.Items.Add("По возрастанию");
                cbSort.Items.Add("По убыванию");

                cbSort.SelectedItem = cbSort.Items[0];

                countAll = clients.Count();
                lbCountAll.Text = countAll.ToString();
                cbSort.SelectedIndex = 0;

            }
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
            LoadClientsToGrid();
        }
        int countAll, filterAbonements, countCurrent, filterSort;




        public void LoadClientsToGrid()
        {
            timer.Start();
            listClients.Items.Clear();
            string searchText = tbSearch.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(searchText))
            {
                timer.Stop();
                string[] searchWords = searchText.Split(' ');

                using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
                {
                    var clients = context.Clients.Include(c => c.Abonements).ToList();

                    // Очистка списка перед добавлением клиентов
                    if (filterAbonements != 0)
                    {
                        clients = clients.Where(x => x.abonementID == filterAbonements).ToList();
                    }

                    switch (cbSort.SelectedIndex)
                    {
                        default:
                            break;
                        case 1:
                            clients = clients.OrderBy(x => x.clientCountOfTrainings).ToList();
                            break;
                        case 2:
                            clients = clients.OrderByDescending(x => x.clientCountOfTrainings).ToList();
                            break;
                    }

                    var filteredClients = clients.Where(client =>
                        searchWords.All(word =>
                            client.clientName.ToLower().Contains(word) ||
                            client.clientSurname.ToLower().Contains(word) ||
                            client.clientPatronymic.ToLower().Contains(word)
                        )
                    );

                    listClients.Items.Clear();

                    foreach (var client in filteredClients)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.DataContext = client;
                        listViewItem.Content = new
                        {
                            Name = client.clientName,
                            Surname = client.clientSurname,
                            Patronymic = client.clientPatronymic,
                            CountOfTrainings = client.clientCountOfTrainings,
                            AbonementType = client.Abonements.abonementType,
                            UID = client.clientUID
                        };

                        listClients.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
                {
                    var clients = context.Clients.Include(c => c.Abonements).ToList();

                    // Очистка списка перед добавлением клиентов
                    if (filterAbonements != 0)
                    {
                        clients = clients.Where(x => x.abonementID == filterAbonements).ToList();
                    }

                    switch (cbSort.SelectedIndex)
                    {
                        default:
                            break;
                        case 1:
                            clients = clients.OrderBy(x => x.clientCountOfTrainings).ToList();
                            break;
                        case 2:
                            clients = clients.OrderByDescending(x => x.clientCountOfTrainings).ToList();
                            break;
                    }


                    foreach (var client in clients)
                    {
                        ListViewItem listViewItem = new ListViewItem();
                        listViewItem.DataContext = client;
                        listViewItem.Content = new
                        {
                            Name = client.clientName,
                            Surname = client.clientSurname,
                            Patronymic = client.clientPatronymic,
                            CountOfTrainings = client.clientCountOfTrainings,
                            AbonementType = client.Abonements.abonementType,
                            UID = client.clientUID
                        };

                        listClients.Items.Add(listViewItem);
                    }
                }
            }
        }


        DispatcherTimer timer = new DispatcherTimer();
        public void RefreshList()
        {

            using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
            {
                List<Entity.Clients> clients = context.Clients.ToList();

                if (clients.Count != listClients.Items.Count)
                {
                    LoadClientsToGrid();
                    countAll = clients.Count();
                    lbCountAll.Text = countAll.ToString();

                }

            }

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void cbAbonement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterAbonements = cbAbonement.SelectedIndex;
            LoadClientsToGrid();

        }

        private void DelClients(object sender, RoutedEventArgs e)
        {
            var selectedItem = listClients.SelectedItem as ListViewItem;

            using (ForsajFitnessEntities1 usersEntities = new ForsajFitnessEntities1())
            {
                if (selectedItem != null)
                {
                    var selectedClient = selectedItem.DataContext as Entity.Clients;
                    if (selectedClient != null)
                    {
                        var clientID = selectedClient.clientID;

                        // Показать MessageBox для подтверждения удаления
                        var result = MessageBox.Show("Учтите, что после удаления клиента из списка, все данные о нем будут стерты. Вы уверены, что хотите продолжить?", "Подтверждение удаления", MessageBoxButton.OKCancel);

                        if (result == MessageBoxResult.OK)
                        {
                            // Удаление записей клиента из таблицы "Sales"
                            var salesToDelete = usersEntities.Sales.Where(s => s.clientID == clientID).ToList();
                            foreach (var sale in salesToDelete)
                            {
                                usersEntities.Sales.Remove(sale);
                            }

                            // Удаление записей клиента из таблицы "VisitHistory"
                            var visitHistoryToDelete = usersEntities.VisitHistory.Where(v => v.clientID == clientID).ToList();
                            foreach (var visit in visitHistoryToDelete)
                            {
                                usersEntities.VisitHistory.Remove(visit);
                            }

                            // Удаление самого клиента из таблицы "Clients"
                            var clientToDelete = usersEntities.Clients.FirstOrDefault(c => c.clientID == clientID);
                            if (clientToDelete != null)
                            {
                                usersEntities.Clients.Remove(clientToDelete);
                            }

                            usersEntities.SaveChanges();
                        }
                    }
                }

                var clients = usersEntities.Clients.ToList();
                countAll = clients.Count();
                lbCountAll.Text = countAll.ToString();
                listClients.ItemsSource = null;
                LoadClientsToGrid();
            }
        }



        private bool isScanFormOpen = false;
        private Scaning scan;
        private AddClients addClients;
        private void btnScan_Click(object sender, RoutedEventArgs e)
        {

            if (!isScanFormOpen)
            {
                scan = new Scaning();
                scan.Closed += Scaning_Closed; // Добавляем обработчик события Closed
                scan.Show();
                isScanFormOpen = true;
            }

        }
        private void AddClients_Closed(object sender, EventArgs e)
        {
            isScanFormOpen = false;
        }
        private void btnAddClients_Click(object sender, RoutedEventArgs e) //чтобы при открытой форме и нажатии на кнопку открытия этой же формы она не открывалась
        {
            if (!isScanFormOpen)
            {
                addClients = new AddClients();
                addClients.Closed += AddClients_Closed; // Добавляем обработчик события Closed
                addClients.Show();
                isScanFormOpen = true;
            }
        }

        private void tbSearch_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            tbSearch.Text = "";
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            LoadClientsToGrid();

        }

        private void listClients_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (listClients.SelectedItem != null)
            {
                ListViewItem listViewItem = (ListViewItem)listClients.SelectedItem;
                Entity.Clients selectedClient = (Entity.Clients)listViewItem.DataContext;

                // Открыть форму редактирования клиента
                EditClient editClientForm = new EditClient(selectedClient);
                editClientForm.ShowDialog();

                // После закрытия формы редактирования, обновить список клиентов
                LoadClientsToGrid();
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadClientsToGrid();
        }

        private void Scaning_Closed(object sender, EventArgs e)
        {
            isScanFormOpen = false;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Stop();
        }

    }
}
