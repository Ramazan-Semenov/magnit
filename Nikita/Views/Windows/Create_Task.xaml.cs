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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Create_Task : Window
    {
        public Create_Task()
        {
            InitializeComponent();
            //BuildDates();
            DataContext = new Vm();
            UserLB.Content=" "+System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Запрос явный?","Подтверждение", MessageBoxButton.YesNoCancel);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("Заявка отправлена сотруднику");
                this.Close();
            }
          else  if (messageBoxResult == MessageBoxResult.No)
            {
                MessageBox.Show("Заявка отправлена координатору");
                this.Close();
            }
        }
        //public ObservableCollection<IHierarchy<DateTime>> Dates { get; set; }
        //private void BuildDates()
        //{
        //    var start = new DateTime(2010, 01, 01);

        //    var end = new DateTime(2015, 12, 31);

        //    var dates = new List<DateTime>();

        //    for (var date = start; date <= end; date = date.AddDays(1))
        //    {
        //        dates.Add(date);
        //    }

        //    var d = from date in dates
        //            group date by date.Year into year
        //            select new DateHierarchy
        //            {
        //                Level = 1,
        //                Value = new DateTime(year.Key, 1, 1),
        //                Children = from date in year
        //                           group date by date.Month into month
        //                           select new DateHierarchy
        //                           {
        //                               Level = 2,
        //                               Value = new DateTime(year.Key, month.Key, 1),
        //                               Children = from day in month
        //                                          select new DateHierarchy
        //                                          {
        //                                              Level = 3,
        //                                              Value = day,
        //                                              Children = null
        //                                          }
        //                           }
        //            };

        //    Dates = new ObservableCollection<IHierarchy<DateTime>>(d);
        //}

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }
    }
    //public class DateHierarchy : IHierarchy<DateTime>
    //{
    //    public DateTime Value { get; set; }

    //    public IEnumerable<IHierarchy<DateTime>> Children { get; set; }

    //    public int Level { get; set; }
    //}
    //public interface IHierarchy<T>
    //{
    //    T Value { get; set; }

    //    IEnumerable<IHierarchy<T>> Children { get; set; }

    //    int Level { get; set; }
    //}
}
