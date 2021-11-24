using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Model.CrudOp
{
    internal class Repository
    {
        private readonly SqlConnection _dbconnection;
        private List<task_book> _task_book;
      //  private readonly OrmAdapterModel _ormAdapterModel;
        public Repository(SqlConnection dbconnection)
        {
            _dbconnection = dbconnection;
         //   _ormAdapterModel = new OrmAdapterModel(_dbconnection);
        }

        public void Update(OrmBaseModel ormBaseModel)
        {
            ormBaseModel.Update(_dbconnection);
        }

        public void Delete(OrmBaseModel ormBaseModel)
        {
            ormBaseModel.Delete(_dbconnection);
        }

        public void Insert(OrmBaseModel ormBaseModel)
        {
            ormBaseModel.Insert(_dbconnection);
        }


        //public List<task_book> Task_book
        //{
        //    get
        //    {
        //        return ((new task_book()).Select<task_book>(_dbconnection));
        //    }
        //}


    }
}
