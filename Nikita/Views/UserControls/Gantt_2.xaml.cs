using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Nikita
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Gantt_2 : UserControl
    {
        public Gantt_2()
        {
            InitializeComponent();
            Add(o:"1", taskname: "Дни", count:31);
            Add(10,20,fo:Brushes.Gray, taskname: "Task_1",count: 31);
            Add(3, 8, taskname: "Task_2", count: 31);
            Add(4, 14,fo: Brushes.Aqua, taskname:"Task_3", count: 31);


            Button button = new Button() { Content="-------------", Background=Brushes.Black};
            Grid.SetColumn(button,0);
            Grid.SetRow(button, 0);
            Grid.SetRowSpan(button,2);
            Grid.SetColumnSpan(button, 4);
            Grid1.Children.Add(button);
            //Grid1.SetColumn(button,1);
            //  icTodoList.ItemsSource = items;
            DataContext = this;
        }

        public ObservableCollection<Das> das { get; set; }  = new ObservableCollection<Das>();

        private ObservableCollection<DayModel> Day
        {
            get;
            set;
        }
        public void Add(  int from=0, int before=0, SolidColorBrush fo = null, string o="0", string taskname = "", int count=0,string status="")
        {
            Das h = new Das();
            h.Day = new ObservableCollection<DayModel>();
            SolidColorBrush fore=null;
            if (fo==null)
            {
                fo = Brushes.Red;
            }
            if (o == "1")
            {
                fore = Brushes.Black;
            }
            if (o == "0")
            {
                fore = Brushes.Transparent;
            }
            for (int i = 1, j = 0; i <= count; ++i, j++)
                {

                    if ((i >= from) & (i <= before))
                    {

                    h.Day.Add(new DayModel
                    {
                        color = fo,
                        date = j + 1,
                        fore = fore

                    }); ;
                    }
                    else
                    {

                        h.Day.Add(new DayModel
                        {
                          
                            color = System.Windows.Media.Brushes.White,
                            date = j + 1,
                            fore = fore
                        }); ;
                    }
                }
            h.taskname = taskname;

            das.Add(h);
           
        }
    }
  
    public class Das
    {

        public ObservableCollection<DayModel> Day
        {
            get; set;
        }
        public string taskname { get; set; }
        public string datestart { get; set; } = "20.01.21";

        public string dateend { get; set; }= "22.02.22";

        public string status { get; set; } = new List<string> {"Принят", "Завершен", "В работе" }[0];
        public List<string> statuslist { get; set; } = new List<string> { "Принят", "Завершен", "В работе" };



    }
    public class DayModel
    {
        
        public int date { get; set; }
        public Brush color { get; set; }
        public Brush fore { get; set; }

    }
}
