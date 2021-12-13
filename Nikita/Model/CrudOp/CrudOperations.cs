using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Model.CrudOp
{
    public class CrudOperations : ConnectionDataBase, ICrudOperations<task_book>
    {
        private bool disposedValue;

        public void Create(task_book item)
        {
            string txt = "INSERT INTO [dbo].[task_book] " +
               "( [Date_of_compilation], [from_whom], [task_type], [name_of_the_task], [start_date], [end_date], [executor], [priority], [status])" +
               " VALUES ( @Date_of_compilation, @from_whom, @task_type, @name_of_the_task, @start_date, @end_date, @executor, @priority, @status)";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                    {
                        //Numder = item.Number,
                        Date_of_compilation = item.Date_of_compilation,
                        from_whom = item.from_whom,
                        task_type = item.task_type,
                        name_of_the_task = item.name_of_the_task,
                        start_date = item.start_date,
                        end_date = item.end_date,
                        executor = item.executor,
                        priority = item.priority,
                        status = item.status
                    });
                connection.Close();
            }
        }

        public void Delete(object id)
        {
            string txt = "DELETE task_book where Number=@id";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt,
                    new
                {
                        Number = id
                    });
                connection.Close();
            }
        }

        public task_book GetEntity(object id)
        {
            task_book task_Book = new task_book();
            string txt = "Select * from task_book where Number=@Number";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                task_Book = connection.Query<task_book>(txt,
                    new
                    {
                        Number = id


                    }).First();

             
                connection.Close();
            }
            return task_Book;
        }

        public IEnumerable<task_book> GetEntityList()
        {
            List<task_book> students = new List<task_book>();
            string txt = "Select * from task_book";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<task_book>(txt).AsParallel().ToList();
                connection.Close();
            }



            return students;
        }

        public void Update(task_book item)
        {
            //"([Numder], [Date_of_compilation], [from_whom], [task_type], [name_of_the_task], [start_date], [end_date], [executor], [priority], [status])" +
            //" VALUES (@Numder,
            //@Date_of_compilation,
            //@from_whom,
            //@task_type, @name_of_the_task, @start_date,
            //@end_date, @executor, @priority, @status)";

            string txt = @"
UPDATE task_book
SET Date_of_compilation = @Date_of_compilation
, from_whom = @from_whom
, task_type = @task_type
, name_of_the_task = @name_of_the_task
, start_date = @start_date
, end_date = @end_date
, executor = @executor
, priority = @priority
, status = @status
WHERE Number = @Number";
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(txt, new
                {
                    Number = item.Number,
                    Date_of_compilation = item.Date_of_compilation,
                    from_whom = item.from_whom,
                    task_type = item.task_type,
                    name_of_the_task = item.name_of_the_task,
                    start_date = item.start_date,
                    end_date = item.end_date,
                    executor = item.executor,
                    priority = item.priority,
                    status = item.status
                });
                connection.Close();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~CrudOperations()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
