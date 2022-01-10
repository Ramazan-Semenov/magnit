using Nikita.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Nikita.ViewModel.StaffViewModel
{
  public class StaffViewModel :Base.BaseViewModel

    {
        private ObservableCollection< Model.task_book> NewTask;
        private SqlTableDependency<task_book> dep;
        public List<task_book> Task_Books { get; set; }
        public string g { get; set; } = "dfdf";
        public ObservableCollection<Model.task_book> newTask { get=>NewTask; set { NewTask = value;OnPropertyChanged(nameof(newTask)); } }
        private Model.ConnectionDataBase _con;
        public StaffViewModel()
        {
            NewTask = new ObservableCollection<Model.task_book>();
            newTask= new ObservableCollection<Model.task_book>( new Model.CrudOp.CrudOperations().GetEntityList().Where(x => x.executor == "Рома").ToList());
            _con = new ConnectionDataBase();
            Task_Books = new List<task_book>();
            Task_Books = (List<task_book>)new Model.CrudOp.CrudOperations().GetEntityList().Where(x=>x.executor=="Рома").ToList();
            Start();

        }
        public void Start()
        {

            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


             dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper);

            if (dep.Status != TableDependency.SqlClient.Base.Enums.TableDependencyStatus.Starting)
            {
                //MessageBox.Show("d");
                dep.OnChanged += Changed;
                dep.Start();
            }

            //Console.WriteLine("Press a key to exit");
            //task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList())


        }
        ~StaffViewModel()
        {
            dep.Stop();
        }

        public void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
            //var changedEntity = e.Entity;
            //NewTask = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList());
            if (e.Entity.executor== Staff.Name)
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    NewTask.Add(e.Entity);
                });
            }          
            //MessageBox.Show(e.Entity.executor);
            OnPropertyChanged("newTask");


        }

        private IList<task_book> dataContext;

        public IList<task_book> DataContext { get => dataContext; set => Set(ref dataContext, value); }

        private IList<task_book> task_Book;

        public IList<task_book> Task_Book { get => task_Book; set => Set(ref task_Book, value); }




    }
}
