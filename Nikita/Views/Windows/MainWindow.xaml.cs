using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\ConsoleApp1\ConsoleApp1\Database1.mdf;Integrated Security=True;Connect Timeout=30");


            connection.Open();
            Console.WriteLine("Start1");
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT TOP(100) [Id] ,[FirstName] ,[LastName] ,[Manager] ,[Salary] ,[StartDate]  FROM [dbo].[Employe]", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            //M.FilteredList = dataTable;

        }
        //    DataView Table;
        //    string prop = "";
        //    static List<j> fl = new List<j>();

        //    string filt = "";
        //    Dictionary<string, ObservableCollection<FilterObj>> filters;
        //    ObservableCollection<FilterObj> objs;
        //    public MainWindow()
        //    {
        //        InitializeComponent();
        //        DataTable dataTable = new DataTable();

        //        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\ConsoleApp1\ConsoleApp1\Database1.mdf;Integrated Security=True;Connect Timeout=30");


        //        connection.Open();
        //        Console.WriteLine("Start1");

        //        SqlCommand command = new SqlCommand("SELECT [Id] ,[FirstName] ,[LastName] ,[Manager] ,[Salary] ,[StartDate] FROM [dbo].[Employe]", connection);

        //       SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(dataTable);
        //        connection.Close();
        //        gr.ItemsSource = dataTable.AsDataView();

        //    }
        //    class j
        //    {
        //        public j(string prop, string value)
        //        {
        //            this.prop = prop;
        //            this.value = value;
        //        }
        //        public string prop { get; set; }
        //        public string value { get; set; }
        //        public override string ToString()
        //        {
        //            return prop + " <> '" + value + "'";
        //        }
        //    }
        //    private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        //    {
        //        var index = e.Row.GetIndex() + 1;
        //        e.Row.Header = $"{index}";

        //    }



        //    private void DataGridColumnHeader_Click(object sender, RoutedEventArgs e)
        //    {

        //    }

        //    private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //    {
        //        var b = (sender as CheckBox).Content.ToString();
        //        foreach (var flt in objs)
        //        {
        //            if (flt.Title == prop)
        //            {
        //                flt.IsChecked = true;
        //                break;
        //            }
        //        }
        //        for (int i = 0; i < fl.Count; i++)
        //        {
        //            if ((fl[i].prop == prop) && (fl[i].value == b))
        //            {
        //                if (fl.Remove(fl[i]))
        //                {
        //                    Debug.WriteLine("Remove");
        //                }
        //            }
        //        }


        //    }
        //    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        //    {
        //        var b = (sender as CheckBox).Content.ToString();
        //        foreach (var flt in objs)
        //        {
        //            if (flt.Title == prop)
        //            {
        //                flt.IsChecked = false;
        //                break;
        //            }
        //        }
        //        fl.Add(new j(prop, b));

        //    }

        //    private void lbFilter_Selected(object sender, RoutedEventArgs e)
        //    {

        //    }

        //    private void ok_Click(object sender, RoutedEventArgs e)
        //    {
        //        filt = "";
        //        foreach (var item in fl)
        //        {
        //            filt += " " + item.ToString();
        //            filt += " And";

        //        }
        //        if (filt != null)
        //        {
        //            if (filt.Length - 4 > 0)
        //            {
        //                filt = filt.Remove(filt.Length - 4, 4);
        //            }
        //        }


        //        Table.RowFilter = filt;
        //        gr.ItemsSource = Table;
        //    }

        //    private void DataGridColumnHeader_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //    {

        //    }

        //    private void Button_Click(object sender, RoutedEventArgs e)
        //    {

        //        var columnHeader = sender as Button;
        //        List<string> vs = new List<string>();

        //        foreach (DataRow item in Table.Table.Rows)
        //        {
        //            vs.Add(item[columnHeader.Tag.ToString()].ToString());
        //            prop = columnHeader.Tag.ToString();

        //        }
        //        vs = new List<string>(vs.Distinct());
        //        objs = new ObservableCollection<FilterObj>();

        //        foreach (var item in vs)
        //        {
        //           FilterObj f = new FilterObj() { IsChecked = true, Title = item };
        //            objs.Add(f);
        //        }
        //        if (!filters.ContainsKey(prop))
        //        {
        //            filters.Add(prop, objs);

        //        }

        //        objs = filters[prop];
        //        popExcel.PlacementTarget = columnHeader;
        //        popExcel.IsOpen = true;
        //        lbFilter.ItemsSource = objs;
        //        Lable.Content = "Clean filter '" + prop + "'";
        //    }

        //    private void TextBox_KeyUp(object sender, KeyEventArgs e)
        //    {
        //        lbFilter.ItemsSource = objs.Where(w => w.Title.IndexOf(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0).AsParallel();

        //    }



        //    private void gr_Loaded(object sender, RoutedEventArgs e)
        //    {
        //        filters = new Dictionary<string, ObservableCollection<FilterObj>>();
        //        gr.AlternationCount = 2;
        //        gr.RowBackground = Brushes.LightSkyBlue;//основной цвет строк
        //        gr.AlternatingRowBackground = Brushes.LightYellow;//альтернативный цвет строк
        //        Table = ((DataView)gr.ItemsSource).ToTable().AsDataView();

        //    }


        //}
        //class FilterObj : INotifyPropertyChanged
        //{

        //    private bool _isCheked;
        //    private string _Title;

        //    public string Title
        //    {
        //        get { return _Title; }
        //        set { _Title = value; OnPropertyChanged("Title"); }
        //    }

        //    public bool IsChecked
        //    {
        //        get { return _isCheked; }
        //        set { _isCheked = value; OnPropertyChanged("IsChecked"); }
        //    }

        //    public event PropertyChangedEventHandler PropertyChanged;

        //    public void OnPropertyChanged([CallerMemberName] String prop = "")
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        //    }
        //}
    }
}
