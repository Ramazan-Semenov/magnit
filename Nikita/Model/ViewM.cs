using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Nikita.Model.CrudOp;

namespace Nikita
{
    class ViewM
    {
       public ObservableCollection<task_book> Employes { get; set; }
        public ViewM()
        {
            Employes = new ObservableCollection<task_book>(Gettask_book());
            //            Employes = new ObservableCollection<task_book>
            //{
            //    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=2, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=3, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="дрмиор", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=4, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
            //    new task_book{Numder=5, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" }

            //};

            //InsertStudent(Employes[5]);
        }
        private string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\source\repos\Nikita\Nikita\AppData\Sch.mdf;Integrated Security=True";

        //This method gets all record from student table    
        private List<task_book> Gettask_book()
        {
            List<task_book> students = new List<task_book>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<task_book>("Select * from task_book").ToList();
                connection.Close();
            }

            //SqlConnection s = new SqlConnection(sqlConnectionString);
            //s.Open();


            //Repository rep = new Repository(s);
            
            return students;
        }
        private int InsertStudent(task_book student)
        {
             string txt= "INSERT INTO [dbo].[task_book] " +
                "([Numder], [Date_of_compilation], [from_whom], [task_type], [name_of_the_task], [start_date], [end_date], [executor], [priority], [status])" +
                " VALUES (@Numder, @Date_of_compilation, @from_whom, @task_type, @name_of_the_task, @start_date, @end_date, @executor, @priority, @status)";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        Numder = student.Numder,
                        Date_of_compilation = student.Date_of_compilation,
                        from_whom = student.from_whom,
                        task_type = student.task_type,
                        name_of_the_task = student.name_of_the_task,
                        start_date = student.start_date,
                        end_date = student.end_date,
                        executor = student.executor,
                        priority = student.priority,
                        status = student.status
                    });
                connection.Close();
                return affectedRows;

            }
            //using (var connection = new SqlConnection(sqlConnectionString))
            //{
            //    connection.Open();
            //    var affectedRows = connection.Execute("Insert into task_book (Numder, priority) values (@Numder, @priority)", new { Numder = student.Numder, priority = student.priority });
            //    connection.Close();
            //}
        }

    }
}
