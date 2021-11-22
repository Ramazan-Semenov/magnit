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

namespace Nikita
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : UserControl
    {
        public Window1()
        {
            InitializeComponent();

            DataContext = new ViewM();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void employeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FilterDataGridAuto_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //var index = e.Row.GetIndex() + 1;
            //e.Row.Header = $"{index}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.ShowDialog();
        }
    }
}
