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

namespace Nikita.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Gantt : UserControl
    {

        private DateTime? SelectedDate;
     static  List<TaskSchedules> tasks;
        static string Sost="Месяц";
        public Gantt()
        {
            InitializeComponent();
            DateAct.SelectedDate = DateTime.Now;

            SelectedDate =DateTime.Parse( DateAct.Text);
          //  MessageBox.Show(SelectedDate.ToString());
            DateAct.SelectedDateChanged += DateAct_SelectedDateChanged;

            init(Sost);

            Model.task_book task_ = new Model.task_book();
            task_.start_date = DateTime.Parse("16/12/2021 14:00:00");
            task_.end_date = DateTime.Parse("16/12/2021 19:00:00");

            //int count = (task_.end_date - task_.start_date).Days*24+ (task_.end_date - task_.start_date).Hours;
            //MessageBox.Show(count.ToString()) ;
            var t = new TaskSchedules() { Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №1", end = task_.end_date,
                start = task_.start_date
                                ,
                Status = "В работе",id=0

            };
            var g = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №1123",
                end = DateTime.Parse("16/12/2021 10:00:00"),
                start = DateTime.Parse("16/12/2021 08:00:00")
                                ,
                Status = "Принят",id=1

            };
            var r = new TaskSchedules()
            {
                Description = "Сделать что-то когда-то и с кем-то",
                task = "Какая-то абстрактная задача №12",
                end = DateTime.Parse("6/12/2021 03:00:00"),
                start = DateTime.Parse("4/12/2021 00:00:00")
                ,Status= "Завершен",id=2
            };
            tasks = new List<TaskSchedules>();
            tasks.Add(g);
            tasks.Add(t);
            tasks.Add(r);
           
            //InitSchudule(t);
             PaintSchudle(tasks, Sost);
            //add("Придумать что-то зачем-то и с кем-то", "Какая-то абстрактная задача №2", 5,6);
            DateTime date = new DateTime();
            phonesList.ItemsSource = tasks;
        }

        private void DateAct_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show("sd");
            clean();
            SelectedDate = DateAct.SelectedDate;
            PaintSchudle(tasks, Sost);
           
        }
        /// <summary>
        /// Первичная инициализация, необходима подвести под паттерн mvvm and State
        /// </summary>
        /// <param name="sost"></param>
        public void init(string sost)
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
            else if (sost == "Месяц")
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
                    label.Content = (i).ToString() + "." + SelectedDate.Value.Month.ToString() + " " + DateTime.Parse(string.Format("{0}.{1}.{2}", i, SelectedDate.Value.Month, SelectedDate.Value.Year)).DayOfWeek; /*string.Format("{0:00}:{1:00}", span.Hours, span.Minutes);*/
                 
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
        /// <summary>
        /// Отрисовка на форме
        /// </summary>
        /// <param name="schudule">список задач</param>
        /// <param name="sost"> Состояние задачи</param>
        void PaintSchudle(IEnumerable<TaskSchedules> schudule, string sost)
        {
            if (sost == "День")
            {



                foreach (var item in schudule)
                {
                    if (item.start.Day == SelectedDate.Value.Day)
                    {
                        InitSchudule(item, sost);
                    }
                }
            }
            else if (sost == "Месяц")
            {


                foreach (var item in schudule)
                {
                    if (item.start.Month == SelectedDate.Value.Month)
                    {
                        InitSchudule(item, sost);
                    }
                }
            }
        }
        //void PaintSchudle(TaskSchedules schudule)
        //{

        //    if (schudule.start.Day == SelectedDate.Value.Day)
        //    {
        //        InitSchudule(schudule);
        //    }

        //}
        void clean()
        {

          _guicCanvas.Children.Clear();
        }
        /// <summary>
        /// Засунуть в паттерн State
        /// </summary>
        /// <param name="schudule"> Задача</param>
        /// <param name="sost"> Состояние задачи</param>
        void InitSchudule(TaskSchedules schudule,string sost/*string Description, string task , int start,int end*/)
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
            //  MessageBox.Show(string.Format("{}---{}",));
            if (sost == "Месяц")
            {

                if (schudule.end.Day > schudule.start.Day)
                {

                    int count = (schudule.end - schudule.start).Days;
                    int date_start = (schudule.start.Day - 1) * 30;
                    //int date_start = schudule.start.Day;
                    int date_end = -(30 * (schudule.start.Day + count));
                    //  MessageBox.Show(count.ToString()) ;

                    but button = new but();
                    if (schudule.Status == "Принят")
                    {
                        button.Background = Brushes.Yellow;

                    }
                    else if (schudule.Status == "Завершен")
                    {
                        button.Background = Brushes.Blue;
                    }
                    else if (schudule.Status == "В работе")
                    {
                        button.Background = Brushes.LightGreen;
                    }
                    else
                    {
                        button.Background = Brushes.Red;
                    }
                    button.BorderThickness = new Thickness(0, 0, 1, 1);
                    //  button.Background = Brushes.LightGreen;
                    button.Content = schudule.task;

                    button.Margin = new Thickness(0, date_start, 0, date_end);


                    button.Description = schudule.Description;
                    button.Click += Window1_Click;
                    _guicCanvas.Children.Add(button);
                }
            }
            //     MessageBox.Show(string.Format("{0}---{1}", schudule.end.Day, schudule.start.Day));
            if (sost == "День")
            {
               
                if (schudule.end.Day == schudule.start.Day)
                {

                    int count = (schudule.end - schudule.start).Days * 24 + (schudule.end - schudule.start).Hours;

                    int date_start = schudule.start.Hour * 30;
                    int date_end = -(30 * (schudule.start.Hour + count));
                    //  MessageBox.Show(count.ToString()) ;

                    but button = new but();
                    if (schudule.Status == "Принят")
                    {
                        button.Background = Brushes.Yellow;

                    }
                    else if (schudule.Status == "Завершен")
                    {
                        button.Background = Brushes.Blue;
                    }
                    else if (schudule.Status == "В работе")
                    {
                        button.Background = Brushes.LightGreen;
                    }
                    else
                    {
                        button.Background = Brushes.Red;
                    }
                    button.BorderThickness = new Thickness(0, 0, 1, 1);
                    //  button.Background = Brushes.LightGreen;
                    button.Content = schudule.task;

                    button.Margin = new Thickness(0, date_start, 0, date_end);


                    button.Description = schudule.Description;
                    button.Click += Window1_Click;
                    _guicCanvas.Children.Add(button);
                }
            }


            //mm.Children.Add(button);
        }
        /// <summary>
        /// Переписать под mvvm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window1_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show( (e.Source as but).Description.ToString());
        }
        /// <summary>
        /// Переписать под mvvm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // MessageBox.Show();
            Sost = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            _guicCanvas.Children.Clear();
            init(Sost);
            PaintSchudle(tasks, Sost);

        }
       /// <summary>
       /// Переписать под mvvm
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
           _guicCanvas.Children.Clear();
            for (int i = 0; i < tasks.Count; i++)
            {
                if ( (sender as ComboBox).Tag == tasks[i].id)
                {
                  //  MessageBox.Show((sender as ComboBox).Tag.ToString());
                    tasks[i].Status = (sender as ComboBox).SelectedValue.ToString();
                  

                    PaintSchudle(tasks, Sost);

                }
            }
          
     

        }
    }

    public  class TaskSchedules
    {
        public object id { get; set; }
        public  string Description { get; set; }
        public string Status { get; set; }
        public string task { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public List<string> statuslist { get; set; } = new List<string> { "Принят", "Завершен", "В работе" };

    }
    /// <summary>
    /// Все состаяния "Принят", "Завершен", "В работе"
    /// </summary>
    enum State
    {

    }
    class but:Button
    {
        public string Description { get; set; }
    }
}