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

namespace Nikita.Views.StaffView
{
    /// <summary>
    /// Логика взаимодействия для StaffView.xaml
    /// </summary>
    public partial class StaffView : Page
    {
        Views.UserControls.ListTask listTask = new UserControls.ListTask();
        public StaffView()
        {
            InitializeComponent();
            //M.task_Books= (IList<Model.task_book>)new Model.CrudOp.CrudOperations().GetEntityList();
            DataContext = new ViewModel.StaffViewModel.StaffViewModel();
            //M.DataContext = new ViewModel.StaffViewModel.StaffViewModel();

            //   M.Role = (IList<Model.task_book>)new Model.CrudOp.CrudOperations().GetEntityList();
        }

        private void TabItem_MouseUp(object sender, MouseButtonEventArgs e)
        {
           
         //   M.Role = (IList<Model.task_book>)new Model.CrudOp.CrudOperations().GetEntityList().Where(x => x.executor != "Рома").ToList();
            this.UpdateLayout();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
