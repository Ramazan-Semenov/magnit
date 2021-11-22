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
    public partial class Window4 : UserControl
    {
        public Window4()
        {
            InitializeComponent();
            Add(o:"1");
            Add(10,20,fo:Brushes.Gray);
            Add(3, 8);
            Add(4, 14,fo: Brushes.Aqua);
     


            //  icTodoList.ItemsSource = items;
            DataContext = this;
        }

        public ObservableCollection<Das> das { get; set; }  = new ObservableCollection<Das>();

        private ObservableCollection<DayModel> Day
        {
            get;
            set;
        }
        public void Add(int from=0, int before=0, SolidColorBrush fo = null, string o="0")
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
            for (int i = 1, j = 0; i <= 31; ++i, j++)
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
    }
    public class DayModel
    {
        
        public int date { get; set; }
        public Brush color { get; set; }
        public Brush fore { get; set; }

    }
}
