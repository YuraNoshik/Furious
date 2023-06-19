using Forsaj.Entity;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Forsaj.Views
{
    /// <summary>
    /// Логика взаимодействия для Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        public Schedule()
        {
            InitializeComponent();
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                var trainers = userEntity.Trainers.Select(x => x.trainerFIO).ToList();
                cbTrainer.ItemsSource = trainers;

                var days = userEntity.Days.Select(x => x.dayName).ToList();
                cbDayOfTheWeek.ItemsSource = days;
            }
        }



        private void btnAddTraining_Click(object sender, RoutedEventArgs e)
        {
            using (ForsajFitnessEntities1 userEntity = new ForsajFitnessEntities1())
            {
                int trainer = cbTrainer.SelectedIndex + 1;
                int dayOfTheWeek = cbDayOfTheWeek.SelectedIndex + 1;
                string startTraining = tbStartTime.Text;
                string descsription = tbDescription.Text;



                if (!string.IsNullOrEmpty(tbStartTime.Text) && !string.IsNullOrEmpty(tbDescription.Text))
                {
                    if (cbDayOfTheWeek.SelectedItem != null || cbTrainer.SelectedItem != null)
                    {
                        if (dpDateOfTraining.SelectedDate.HasValue) // Проверяем, выбрана ли дата
                        {
                            DateTime trainingDate = dpDateOfTraining.SelectedDate.Value;

                            Entity.Schedule schedule = new Entity.Schedule
                            {
                                trainerID = trainer,
                                dayID = dayOfTheWeek,
                                trainingTimeStart = startTraining,
                                trainingDescription = descsription,
                                trainingDate = trainingDate,
                                // Другие свойства расписания
                            };

                            userEntity.Schedule.Add(schedule);
                            userEntity.SaveChanges();

                            MessageBox.Show("Тренировка успешно добавлена");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не выбрана дата тренировки");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Один из выпадающих списков не заполнены");
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены");
                }


            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
        private void btnScheduleBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
