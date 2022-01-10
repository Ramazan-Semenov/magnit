using Nikita.Model;
using Nikita.ViewModel;
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
    public partial class ListTask : UserControl
    {
        public static readonly DependencyProperty Task_BooksProperty = DependencyProperty.Register(
          nameof(Task_Book), typeof(IList<task_book>), typeof(ListTask), new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault ));

        public IList<task_book> Task_Book
        {
            get { return (IList<task_book>)GetValue(Task_BooksProperty); }
            set { SetValue(Task_BooksProperty, value); }
        }
        public ListTask()
        {
            InitializeComponent();
            DataContext = this;/*new ViewModel.ListTaskViewModel();*/
        }
       
        //public ListTask(List<task_book> task_Books)
        //{
        //    InitializeComponent();

        //    DataContext = new ViewModel.ListTaskViewModel(task_Books);
        //}
      

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
            //Create_Task window = new Create_Task();
            //window.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //if (Role!=null)
            //{
            DataContext = this;/*new ViewModel.ListTaskViewModel();*/
            //MessageBox.Show(Task_Book.Count.ToString());
            FilterDataGrid.ItemsSource = Task_Book;
            //}



        }
    }
}
