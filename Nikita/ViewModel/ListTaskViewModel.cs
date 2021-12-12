using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Dapper;
using Nikita.Model;

namespace Nikita.ViewModel
{
    class ListTaskViewModel:Base.BaseViewModel
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

        }
    
        #region  Команда для открытия окна редактирования 
        public ICommand EditTask { get; }
        private bool CanGetCommandExecuteEditTask(object param) => true;
        private void OnGetCommandExecuteEditTask(object param)
        {
            if (Selected!=null)
            {
                MessageBox.Show(string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", 
                    Selected.Number, Selected.name_of_the_task, Selected.start_date,
                    Selected.status, Selected.Date_of_compilation, Selected.end_date, Selected.executor)) ;

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

    }
}
