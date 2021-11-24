using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Model.CrudOp
{
    class SqlColumnAttribute : Attribute
    {
        public SqlColumnAttribute(string columnName, string dbType)
        {
            ColumnName = columnName;
            ColumnDbType = dbType;
            IsPrimaryKey = false;
        }

        public string ColumnName { get; set; }
        public string ColumnDbType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsAutoIncrement { get; set; }
    }
}
