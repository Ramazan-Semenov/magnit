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
    class ListTaskViewModel:Base.BaseViewModel, IDisposable
    {
        private ObservableCollection<task_book> task_Books;
        public ObservableCollection<task_book> Task_Books { get => task_Books; set 
            {
                task_Books= value; OnPropertyChanged(nameof(Task_Books));
            } }

        public task_book Selected { get; set; }
        public ListTaskViewModel()
        {
            task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList());
            //Task_Books = new ObservableCollection<task_book>();
            EditTask = new Controls.LambdaCommand(OnGetCommandExecuteEditTask, CanGetCommandExecuteEditTask);
            CreateTask = new Controls.LambdaCommand(OnGetCommandExecuteCreateTask, CanGetCommandExecuteCreateTask);
            DeleteTask = new Controls.LambdaCommand(OnGetCommandExecuteDeleteTask, CanGetCommandExecuteDeleteTask);
            //            Employes = new ObservableCollection<task_book>
            //{
            //    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=2, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=3, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="дрмиор", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=4, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=5, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" }

            //};
            _con = new ConnectionDataBase();
            Thread thread = new Thread(Start);
            thread.Start();
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
                MessageBox.Show("d");
                dep.OnChanged += Changed;
                dep.Start();
            }

            //Console.WriteLine("Press a key to exit");
            //task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList())


        }

        public  void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
            //var changedEntity = e.Entity;
            task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList());
            OnPropertyChanged("Task_Books");
            //MessageBox.Show("DML operation: " + e.ChangeType);

            //Console.WriteLine("DML operation: " + e.ChangeType);
            //Console.WriteLine("Number: " + changedEntity.Number);
            //Console.WriteLine("executor: " + changedEntity.executor);
            //Console.WriteLine("from_whom: " + changedEntity.from_whom);
            //Console.WriteLine("Date_of_compilation: " + changedEntity.Date_of_compilation);
            //Console.WriteLine("start_date: " + changedEntity.start_date);
            //Console.WriteLine("end_date: " + changedEntity.end_date);

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
