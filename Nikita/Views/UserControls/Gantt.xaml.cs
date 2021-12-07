﻿using System;
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

namespace Nikita.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Gantt : UserControl
    {

        private DateTime? SelectedDate;
        List<TaskSchedules> tasks;
        public Gantt()
        {
            InitializeComponent();
            DateAct.SelectedDate = DateTime.Now;

            SelectedDate =DateTime.Parse( DateAct.Text);
            MessageBox.Show(SelectedDate.ToString());
            DateAct.SelectedDateChanged += DateAct_SelectedDateChanged;

            init();

            Model.task_book task_ = new Model.task_book();
            task_.start_date = DateTime.Parse("1/12/2021 8:00:00");
            task_.end_date = DateTime.Parse("1/12/2021 19:00:00");

            //int count = (task_.end_date - task_.start_date).Days*24+ (task_.end_date - task_.start_date).Hours;
            //MessageBox.Show(count.ToString()) ;
            var t = new TaskSchedules() { Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №1", end = task_.end_date,
                start = task_.start_date
            };
            var g = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №1123",
                end = DateTime.Parse("2/12/2021 10:00:00"),
                start = DateTime.Parse("2/12/2021 08:00:00")
            };
            var r = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №12",
                end = DateTime.Parse("6/12/2021 03:00:00"),
                start = DateTime.Parse("4/12/2021 00:00:00")
            };
            tasks = new List<TaskSchedules>();
            tasks.Add(g);
            tasks.Add(t);
            tasks.Add(r);
            //InitSchudule(t);
             PaintSchudle(tasks);
            //add("Придумать что-то зачем-то и с кем-то", "Какая-то абстрактная задача №2", 5,6);
            DateTime date = new DateTime();
        }

        private void DateAct_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show("sd");
            clean();
            SelectedDate = DateAct.SelectedDate;
            PaintSchudle(tasks);
           
        }

        public void init(string sost= "Месяц")
        {
            _guicGridTimeline.Children.Clear();
            int day_yeer_mouth = 0;
            TimeSpan span = new TimeSpan();
            TimeSpan time = new TimeSpan(1, 0, 0);
            Label label = new Label();
            if (sost=="День")
            {
                day_yeer_mouth = 23;
               
                label.BorderThickness = new Thickness(0, 0, 1, 1);
                for (int i = 0; i <= day_yeer_mouth; i++)
                {
                    label = new Label();
                    label.Height = 30;
                    label.BorderThickness = new Thickness(0, 0, 1, 1);
                    label.BorderBrush = Brushes.Black;
                    label.Content = string.Format("{0:00}:{1:00}", span.Hours, span.Minutes);
                    _guicGridTimeline.Children.Add(label);

                    span = span.Add(time);
                }
            }
            else if(sost == "Месяц")
            {
                day_yeer_mouth = DateTime.DaysInMonth(SelectedDate.Value.Year, SelectedDate.Value.Month);
                //TimeSpan time = new TimeSpan(1, 0, 0);
                //Label label = new Label();
                label.BorderThickness = new Thickness(0, 0, 1, 1);
                for (int i = 1; i <= day_yeer_mouth; i++)
                {
                    label = new Label();
                    label.Height = 30;
                    label.BorderThickness = new Thickness(0, 0, 1, 1);
                    label.BorderBrush = Brushes.Black;
                    label.Content = (i).ToString() + "."+ SelectedDate.Value.Month.ToString()+" "+DateTime.Parse(string.Format("{0}.{1}.{2}",i, SelectedDate.Value.Month, SelectedDate.Value.Year)).DayOfWeek; /*string.Format("{0:00}:{1:00}", span.Hours, span.Minutes);*/
                    _guicGridTimeline.Children.Add(label);

                    span = span.Add(time);
                }
            }
        
            //TimeSpan time = new TimeSpan(1, 0, 0);
            //Label label = new Label();
            //label.BorderThickness = new Thickness(0, 0, 1, 1);
            //for (int i = 0; i <= day_yeer_mouth; i++)
            //{
            //    label = new Label();
            //    label.Height = 30;
            //    label.BorderThickness = new Thickness(0, 0, 1, 1);
            //    label.BorderBrush = Brushes.Black;
            //    label.Content = string.Format("{0:00}:{1:00}", span.Hours, span.Minutes);
            //    _guicGridTimeline.Children.Add(label);

            //    span = span.Add(time);
            //}

        }
        void PaintSchudle(IEnumerable<TaskSchedules> schudule)
        {
          
            //foreach (var item in schudule)
            //{
            //    if (item.start.Day == SelectedDate.Value.Day)
            //    {
            //        InitSchudule(item);
            //    }
            //}

            foreach (var item in schudule)
            {
                if (item.start.Month == SelectedDate.Value.Month)
                {
                    InitSchudule(item);
                }
            }

        }
        void PaintSchudle(TaskSchedules schudule)
        {

            if (schudule.start.Day == SelectedDate.Value.Day)
            {
                InitSchudule(schudule);
            }

        }
        void clean()
        {

          _guicCanvas.Children.Clear();
        }
        void InitSchudule(TaskSchedules schudule/*string Description, string task , int start,int end*/)
        {
            //if (true)
            //{
            //    int count = (schudule.end - schudule.start).Days * 24 + (schudule.end - schudule.start).Hours;

            //    int date_start = schudule.start.Hour * 30;
            //    int date_end = -(30 * (schudule.start.Hour + count));
            //    but button = new but();
            //    button.BorderThickness = new Thickness(0, 0, 1, 1);
            //    button.Background = Brushes.LightGreen;
            //    button.Content = schudule.task;

            //    button.Margin = new Thickness(0, date_start, 0, date_end);


            //    button.Description = schudule.Description;
            //    button.Click += Window1_Click;
            //    _guicCanvas.Children.Add(button);
            //}
             if (true)
            {
                int count = (schudule.end - schudule.start).Days;
                int date_start = (schudule.start.Day-1)*30;
                //int date_start = schudule.start.Day;
                int date_end = -(30 * (schudule.start.Day+count));
                MessageBox.Show(count.ToString()) ;

                but button = new but();
                button.BorderThickness = new Thickness(0, 0, 1, 1);
                button.Background = Brushes.LightGreen;
                button.Content = schudule.task;

                button.Margin = new Thickness(0, date_start, 0, date_end);


                button.Description = schudule.Description;
                button.Click += Window1_Click;
                _guicCanvas.Children.Add(button);
            }
            

            //mm.Children.Add(button);
        }
        private void Window1_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show( (e.Source as but).Description.ToString());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show();

            init(((sender as ComboBox).SelectedItem as TextBlock).Text);

        }
    }

    public  class TaskSchedules
    {
        public  string Description { get; set; }
        public string task { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
    class but:Button
    {
        public string Description { get; set; }
    }
}