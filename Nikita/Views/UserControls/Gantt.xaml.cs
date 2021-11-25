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
        public Gantt()
        {
            InitializeComponent();
            init();
            add("sdad",0,1);
            add("fasfda",5,6);
            DateTime date = new DateTime();
        }
        public void init()
        {
            TimeSpan span = new TimeSpan();
            TimeSpan time = new TimeSpan(1 ,0 ,0);
            Label label = new Label();
            label.BorderThickness = new Thickness(0,0,1,1);
            for (int i = 0; i <= 23; i++)
            {
                label = new Label();
                label.Height = 30;
                label.BorderThickness = new Thickness(0, 0, 1, 1);
                label.BorderBrush = Brushes.Black;
                label.Content = string.Format("{0:00}:{1:00}", span.Hours, span.Minutes);
                //_guicGridTimeline.Children.Add(label) ;
                _guicGridTimeline.Children.Add(label);

                span = span.Add(time);
            }
          
        }
        void add( string task , int start,int end)
        {
            but button = new but { Width = 100, BorderThickness = new Thickness(0, 0, 1, 1), Background = Brushes.LightGreen, Content = task, Margin = new Thickness(0, start*30, 0, -30 * end) };
            button.Description = "sadbhefgvpuiewrbfvpiwerwihvbpiweb";
            button.Click += Window1_Click;
            //_guicCanvas.Children.Add(button);

            mm.Children.Add(button);
        }
        private void Window1_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show( (e.Source as but).Description.ToString());
        }
    }
    class but:Button
    {
        public string Description { get; set; }
    }

}
