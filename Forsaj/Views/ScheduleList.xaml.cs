using Forsaj.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для ScheduleList.xaml
    /// </summary>
    public partial class ScheduleList : Page
    {
        int filterTrainer = 0;
        int filterDays= 0;
        public ScheduleList()
        {
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                InitializeComponent();


                


                cbTrainersList.Items.Add("Тренер");
                var trainers = userEntity.Trainers.Select(x => x.trainerFIO).ToList();
                cbTrainersList.SelectedItem = cbTrainersList.Items[0];
                foreach (var trainer in trainers)
                {
                    cbTrainersList.Items.Add(trainer);
                }

                cbDayList.Items.Add("День");
                var days = userEntity.Days.Select(x => x.dayName).ToList();
                cbDayList.SelectedItem = cbDayList.Items[0];
                foreach (var day in days)
                {
                    cbDayList.Items.Add(day);
                }

                LoadSchedule();
            }
        }
        public void LoadSchedule()
        {
            ListSchedule.ItemsSource = null;
            DateTime selectedDate = dpSchedule.SelectedDate ?? DateTime.MinValue;

            using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
            {
                var query = context.Schedule.Include(x => x.Trainers).Include(x => x.Days).AsQueryable();

                if (filterTrainer != 0)
                {
                    query = query.Where(x => x.trainerID == filterTrainer);
                }

                if (filterDays != 0)
                {
                    query = query.Where(x => x.dayID == filterDays);
                }

                if (selectedDate != DateTime.MinValue)
                {
                    query = query.Where(x => x.trainingDate.Date == selectedDate.Date);
                }

                var trains = query.ToList();

                ListSchedule.ItemsSource = trains;
            }
        }



        private void btnDeleteClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTraininigs_Click(object sender, RoutedEventArgs e)
        {
            new Schedule().Show();
        }

        private void cbTrainersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterTrainer = cbTrainersList.SelectedIndex;
            LoadSchedule();
        }

        private void cbDayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterDays = cbDayList.SelectedIndex;
            LoadSchedule();
        }

        private void dpSchedule_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
            LoadSchedule();
        }

        private void picRefreshDateHistory_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            dpSchedule.SelectedDate = null;
            cbDayList.SelectedItem = cbDayList.Items[0];
            cbTrainersList.SelectedItem = cbTrainersList.Items[0];
            LoadSchedule();
        }

        private void btnDeleteClients_Click_1(object sender, RoutedEventArgs e)
        {
            List<Entity.Schedule> selectedTrainings = ListSchedule.SelectedItems.Cast<Entity.Schedule>().ToList();

            foreach (var item in ListSchedule.SelectedItems)
            {
                if (item is Entity.Schedule training)
                {
                    selectedTrainings.Add(training);
                }
            }

            using (ForsajFitnessEntities1 context = new ForsajFitnessEntities1())
            {
                foreach (var training in selectedTrainings)
                {
                    context.Entry(training).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }

            LoadSchedule(); // Перезагрузка данных в ListView
        }
        
    }
}
