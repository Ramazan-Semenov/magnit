using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Dapper;
using Nikita.Model;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Nikita.ViewModel
{
  public  class ListTaskViewModel:Base.BaseViewModel, IDisposable
    {
      
        private static ObservableCollection<task_book> task_Books;
        public static ObservableCollection<task_book> Task_Books { get => task_Books; set 
            {
                task_Books= value; /*OnPropertyChanged(nameof(Task_Books))*/;
            } }

        public task_book Selected { get; set; }
        public ListTaskViewModel( string txt)
        {
            MessageBox.Show(txt);
            //task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList());
            ////Task_Books = new ObservableCollection<task_book>();
            //EditTask = new Controls.LambdaCommand(OnGetCommandExecuteEditTask, CanGetCommandExecuteEditTask);
            //CreateTask = new Controls.LambdaCommand(OnGetCommandExecuteCreateTask, CanGetCommandExecuteCreateTask);
            //DeleteTask = new Controls.LambdaCommand(OnGetCommandExecuteDeleteTask, CanGetCommandExecuteDeleteTask);
            //Create_based_on = new Controls.LambdaCommand(OnGetCommandExecuteCreate_based_on, CanGetCommandExecuteCreate_based_on);

            //_con = new ConnectionDataBase();

            //Start();
        }
        public ListTaskViewModel()
        {
            task_Books = new ObservableCollection<task_book>(/*new Model.CrudOp.CrudOperations().GetEntityList()*/);
            //Task_Books = new ObservableCollection<task_book>();
            EditTask = new Controls.LambdaCommand(OnGetCommandExecuteEditTask, CanGetCommandExecuteEditTask);
            CreateTask = new Controls.LambdaCommand(OnGetCommandExecuteCreateTask, CanGetCommandExecuteCreateTask);
            DeleteTask = new Controls.LambdaCommand(OnGetCommandExecuteDeleteTask, CanGetCommandExecuteDeleteTask);
            Create_based_on = new Controls.LambdaCommand(OnGetCommandExecuteCreate_based_on, CanGetCommandExecuteCreate_based_on);

            _con = new ConnectionDataBase();

            Start();
        }
        public ListTaskViewModel(List<task_book> tasks)
        {
            task_Books = new ObservableCollection<task_book>(tasks);
            //Task_Books = new ObservableCollection<task_book>();
            EditTask = new Controls.LambdaCommand(OnGetCommandExecuteEditTask, CanGetCommandExecuteEditTask);
            CreateTask = new Controls.LambdaCommand(OnGetCommandExecuteCreateTask, CanGetCommandExecuteCreateTask);
            DeleteTask = new Controls.LambdaCommand(OnGetCommandExecuteDeleteTask, CanGetCommandExecuteDeleteTask);
            Create_based_on = new Controls.LambdaCommand(OnGetCommandExecuteCreate_based_on, CanGetCommandExecuteCreate_based_on);

            _con = new ConnectionDataBase();

            Start();
        }

        private Model.ConnectionDataBase _con;
      
        public void Start()
        {
          
            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


            var dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper);

            if (dep.Status!= TableDependency.SqlClient.Base.Enums.TableDependencyStatus.Starting)
            {
                //MessageBox.Show("d");
                dep.OnChanged += Changed;
                dep.Start();
            }

            //Console.WriteLine("Press a key to exit");
            //task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList())


        }

        public  void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
            task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList());
            //OnPropertyChanged("Task_Books");
     

        }

        public ICommand Create_based_on { get; }
        private bool CanGetCommandExecuteCreate_based_on(object param) => true;
        private void OnGetCommandExecuteCreate_based_on(object param)
        {

            Create_Task window = new Create_Task(Selected);
            window.ShowDialog();

        }
        #region  Команда для открытия окна редактирования 
        public ICommand EditTask { get; }
        private bool CanGetCommandExecuteEditTask(object param) => true;
        private void OnGetCommandExecuteEditTask(object param)
        {
            if (Selected!=null)
            {
            
                Views.Windows.EditTask edit = new Views.Windows.EditTask(Selected);
                edit.Show();

            }
            else
            {
                MessageBox.Show("Не выбрана");
            }
        }
        #endregion

        #region  Команда для удаления записи
        public ICommand DeleteTask { get; }
        private bool CanGetCommandExecuteDeleteTask(object param) => true;
        private void OnGetCommandExecuteDeleteTask(object param)
        {
            if (Selected != null)
            {
                MessageBox.Show(Selected.from_whom);

            }
            else
            {
                MessageBox.Show("Не выбрана");
            }
        }
        #endregion
        #region  Создание нового запроса 
        public ICommand CreateTask { get; }
  

        private bool CanGetCommandExecuteCreateTask(object param) => true;
        private void OnGetCommandExecuteCreateTask(object param)
        {
            Create_Task window = new Create_Task();
            window.ShowDialog();
         
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
        }
        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;

            _Disposed = true;

        }

    }
}
