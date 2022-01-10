using Dapper;
using Nikita.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string userName="";
        public Window3()
        {
            InitializeComponent();
            DataContext = new ViewModel.CurrentWindow();
             userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //GridMain.Content =new Views.Pages.ListTask();

            //Cont.Visibility = Visibility.Collapsed;
            //Cont.Visibility = Visibility.Collapsed;

            //GetEntityList();
            ////DataContext = new ViewModel.ListTaskViewModel();
            //v.Content = userName;
        }
//        public IEnumerable<Model.Role> GetEntityList()
//        {
//            List<Model.Role> students = new List<Model.Role>();
//            string txt = @"select Role_name from Users

//join[User_Role] on Users.Id = User_Role.[User]
//join[Role] on User_Role.Role =[Role].Id

//where Users.[Name]= @N";
//            using (var connection = new SqlConnection(new Model.ConnectionDataBase().sqlConnectionString))
//            {
//                connection.Open();
//                students = connection.Query<Model.Role>(txt,new { N= userName }).ToList();
//                connection.Close();
//            }

//            foreach (var item in students)
//            {
//                if (item.Role_Name == "Админ")
//                {
//                    Cont.Visibility = Visibility.Visible;
//                }
//            }

//            return students;
//        }
        //private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    GridMain.Children.Clear();
        //    switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
        //    {
        //        case "ItemHome":

        //            GridMain.Children.Add(new ListTask());
        //            break;
        //        case "ItemCreate":
        //            GridMain.Children.Add(new Gantt());
        //            break;
        //        case "Cont":                  
        //            GridMain.Children.Add(new Views.ChiefViews.ChiefViewPage());
        //            break;
        //        case "Coordinator":
        //            GridMain.Children.Add(new Views.coordinatorView.CoordinatorViewPage());
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void opendb_Click(object sender, RoutedEventArgs e)
        {
            //GridMain.Children.Clear();
        }
    }
}
