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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nikita.Views.coordinatorView
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorViewPage.xaml
    /// </summary>
    public partial class CoordinatorViewPage : Page
    {

        public CoordinatorViewPage()
        {
            InitializeComponent();
            DataContext = new ViewModel.CoordinatorViewModel.CoordinatorViewModel();
           //MessageBox.Show( M.MyText);
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string Level_1 = (sender as TabItem).Header.ToString();
            string Level_2 = (((sender as TabItem).Content as TabControl).Items[((sender as TabItem).Content as TabControl).SelectedIndex] as TabItem).Header.ToString();
            //MessageBox.Show(string.Format("Level_1: {0} || Level_2: {1}",Level_1,Level_2));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
