using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Nikita.Model;
using Nikita.Model.CrudOp;

namespace Nikita.ViewModel
{
    class ViewM:Base.BaseViewModel
    {
        private ObservableCollection<task_book> task_book;
        public ObservableCollection<task_book> Task_Books { get => task_book; set { task_book = value; OnPropertyChanged(nameof(Task_Books)); } }

        public ViewM()
        {
            task_book = new ObservableCollection<task_book>(new Model.CrudOp.OperationTaskBook().Gettask_book()) ;
            //            Employes = new ObservableCollection<task_book>
            //{
            //    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=2, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=3, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="дрмиор", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=4, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=5, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" }

            //};

        }
      

    }
}
