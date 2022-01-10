using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Nikita
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class FilterDG : UserControl
    {

        public DataTable FilteredList{ get; set; }

        public FilterDG( )
        {
            InitializeComponent();
           
            this.DataContext = this;
        
 

        }
        DataView Table;
        string prop = "";
        static List<j> fl = new List<j>();

        string filt = "";
        Dictionary<string, ObservableCollection<FilterObj>> filters;
        ObservableCollection<FilterObj> objs;


        public ObservableCollection<IHierarchy<DateTime>> Dates { get; set; }
        List<DateTime> dates = new List<DateTime>();
        private void BuildDates(List<DateTime> dates)
        {
            var d = from date in dates
                    group date by date.Year into year
                    select new DateHierarchy
                    {
                        Level = 1,
                        Value = new DateTime(year.Key, 1, 1),
                        Children = from date in year
                                   group date by date.Month into month
                                   select new DateHierarchy
                                   {
                                       Level = 2,
                                       Value = new DateTime(year.Key, month.Key, 1).ToString("dd/MM/yyyy"),
                                       Children = from day in month
                                                  select new DateHierarchy
                                                  {
                                                      Level = 3,
                                                      Value = day.ToString("dd/MM/yyyy"),
                                                      Children = null
                                                  }
                                   }
                    };

            Dates = new ObservableCollection<IHierarchy<DateTime>>(d);
        }

        class j
        {
            public j(string prop, string value)
            {
                this.prop = prop;
                this.value = value;
            }
            public string prop { get; set; }
            public string value { get; set; }
            public override string ToString()
            {
                return prop + " <> '" + value + "'";
            }
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var index = e.Row.GetIndex() + 1;
            e.Row.Header = $"{index}";

        }



        private void DataGridColumnHeader_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var b = (sender as CheckBox).Content.ToString();
            foreach (var flt in objs)
            {
                if (flt.Title == prop)
                {
                    flt.IsChecked = true;
                    break;
                }
            }
            for (int i = 0; i < fl.Count; i++)
            {
                if ((fl[i].prop == prop) && (fl[i].value == b))
                {
                    if (fl.Remove(fl[i]))
                    {
                        Debug.WriteLine("Remove");
                    }
                }
            }


        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var b = (sender as CheckBox).Content.ToString();
            foreach (var flt in objs)
            {
                if (flt.Title == prop)
                {
                    flt.IsChecked = false;
                    break;
                }
            }
            fl.Add(new j(prop, b));

        }

        private void lbFilter_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            filt = "";
            foreach (var item in fl)
            {
                filt += " " + item.ToString();
                filt += " And";

            }
            if (filt != null)
            {
                if (filt.Length - 4 > 0)
                {
                    filt = filt.Remove(filt.Length - 4, 4);
                }
            }



            Table.RowFilter = filt;
               gr.ItemsSource = Table;
           
        }

        private void DataGridColumnHeader_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private bool convertdate(string text)
        {
            try
            {
                
                if (text!="")
                {
                    Convert.ToDateTime(text);

                }
                Tree.Visibility = Visibility.Visible;
                lbFilter.Visibility = Visibility.Collapsed;
                return true;
            }catch
            {
                return false;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var columnHeader = sender as Button;
            List<string> vs = new List<string>();
            dates = new List<DateTime>();
            bool dop = false;
            if (convertdate((Table.Table.Rows[0] as DataRow)[columnHeader.Tag.ToString()].ToString()))
            {
                dop = true;
            }
           
            foreach (DataRow item in Table.Table.Rows)
            {
                if (item[columnHeader.Tag.ToString()].ToString() != "")
                {
                    if (dop)
                    {
                       
                        dates.Add(Convert.ToDateTime(item[columnHeader.Tag.ToString()].ToString()));
                     //   MessageBox.Show(Convert.ToDateTime(item[columnHeader.Tag.ToString()].ToString()).ToString());

                    }else
                    {
                        Tree.Visibility =  Visibility.Hidden;
                    }
                }
                vs.Add(item[columnHeader.Tag.ToString()].ToString());
                prop = columnHeader.Tag.ToString();

            }
            vs = new List<string>(vs.Distinct());
            objs = new ObservableCollection<FilterObj>();

            foreach (var item in vs)
            {
                FilterObj f = new FilterObj() { IsChecked = true, Title = item };
                objs.Add(f);
            }
            if (!filters.ContainsKey(prop))
            {
                filters.Add(prop, objs);

            }
            Dates=new ObservableCollection<IHierarchy<DateTime>>();

            BuildDates(dates);
            Tree.ItemsSource = Dates;
            objs = filters[prop];
            popExcel.PlacementTarget = columnHeader;
            popExcel.IsOpen = true;
            lbFilter.ItemsSource = objs;
            Lable.Content = "Clean filter '" + prop + "'";
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            lbFilter.ItemsSource = objs.Where(w => w.Title.IndexOf(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0).AsParallel();

        }



        private void gr_Loaded(object sender, RoutedEventArgs e)
        {
            filters = new Dictionary<string, ObservableCollection<FilterObj>>();
            gr.AlternationCount = 2;
            gr.RowBackground = Brushes.LightSkyBlue;//основной цвет строк
            gr.AlternatingRowBackground = Brushes.LightYellow;//альтернативный цвет строк
            Table = ((DataView)FilteredList.DefaultView).ToTable().AsDataView();

        }

        private void gr_Initialized(object sender, EventArgs e)
        {
          //  table = new DataTable();
            //DataTable dataTable = new DataTable();

            //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\ConsoleApp1\ConsoleApp1\Database1.mdf;Integrated Security=True;Connect Timeout=30");


            //connection.Open();
            //Console.WriteLine("Start1");

            //SqlCommand command = new SqlCommand("SELECT [Id] ,[FirstName] ,[LastName] ,[Manager] ,[Salary] ,[StartDate] FROM [dbo].[Employe]", connection);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //adapter.Fill(dataTable);
            //connection.Close();
          //  gr.ItemsSource = table.AsDataView();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Table.Sort = prop+ " ASC";
           
            gr.ItemsSource = Table; ;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Table.Sort = prop + " DESC";
            gr.ItemsSource = Table; 
        }

        private void Date_Checked(object sender, RoutedEventArgs e)
        {
            string content = (sender as CheckBox).Tag.ToString();
            string value = (sender as CheckBox).Content.ToString();

            if (content=="2")
            {
                string v = String.Format("StartDate >= # {0} # and StartDate<=# {1} #", DateTime.Parse(value).ToString("MM/01/yyyy"), DateTime.Parse(value).ToString("MM/31/yyyy"));
                Table.RowFilter = v;
            }
            else if(content == "1")
            {
                string v = String.Format("StartDate >= # {0} # and StartDate<=# {1} #", DateTime.Parse(value).ToString("01/01/yyyy"), DateTime.Parse(value).ToString("12/31/yyyy"));
                Table.RowFilter = v;
            }
            else if (content == "3")
            {
                string v = String.Format("StartDate = # {0}# ", DateTime.Parse(value).ToString("MM/dd/yyyy"));
                Table.RowFilter = v;
            }
            gr.ItemsSource = Table;
        }

        private void Date_Unchecked(object sender, RoutedEventArgs e)
        {
            // string content = (sender as CheckBox).Content.ToString();
            Table.RowFilter = "";
            gr.ItemsSource = Table;
        }
    }
    class FilterObj : INotifyPropertyChanged
    {

        private bool _isCheked;
        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; OnPropertyChanged("Title"); }
        }

        public bool IsChecked
        {
            get { return _isCheked; }
            set { _isCheked = value; OnPropertyChanged("IsChecked"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] String prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }


    }
    public class DateHierarchy : IHierarchy<DateTime>
    {
        public object Value { get; set; }
      // public int Value { get; set; }

        public IEnumerable<IHierarchy<DateTime>> Children { get; set; }

        public int Level { get; set; }
    }
    public interface IHierarchy<T>
    {
         object Value { get; set; }
      //  int Value { get; set; }
        IEnumerable<IHierarchy<T>> Children { get; set; }

        int Level { get; set; }
    }
}
