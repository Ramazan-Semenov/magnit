using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Model.CrudOp
{
    class OperationTaskBook:ConnectionDataBase
    {

        public List<task_book> Gettask_book()
        {
            List<task_book> students = new List<task_book>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<task_book>("Select * from task_book").AsParallel().ToList();
                connection.Close();
            }



            return students;
        }
        public int Inserttask_book(task_book student)
        {
            string txt = "INSERT INTO [dbo].[task_book] " +
               "([Number], [Date_of_compilation], [from_whom], [task_type], [name_of_the_task], [start_date], [end_date], [executor], [priority], [status])" +
               " VALUES (@Number, @Date_of_compilation, @from_whom, @task_type, @name_of_the_task, @start_date, @end_date, @executor, @priority, @status)";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        Number = student.Number,
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
        }
    }
}
