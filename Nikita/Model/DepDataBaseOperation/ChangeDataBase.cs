using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Nikita.Model.DepDataBaseOperation
{
    class ChangeDataBase
    {
        private Model.ConnectionDataBase _con;
        ChangeDataBase()
        {
            _con = new ConnectionDataBase();
        }
        public void Start( )
        {

            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


            using (var dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper))
            {
                dep.OnChanged += Changed;
                dep.Start();

                Console.WriteLine("Press a key to exit");
                Console.ReadKey();

                dep.Stop();
            }
        }

        public static void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
            var changedEntity = e.Entity;

            Console.WriteLine("DML operation: " + e.ChangeType);
            Console.WriteLine("Number: " + changedEntity.Number);
            Console.WriteLine("executor: " + changedEntity.executor);
            Console.WriteLine("from_whom: " + changedEntity.from_whom);
            Console.WriteLine("Date_of_compilation: " + changedEntity.Date_of_compilation);
            Console.WriteLine("start_date: " + changedEntity.start_date);
            Console.WriteLine("end_date: " + changedEntity.end_date);

        }
    }
}

