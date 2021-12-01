using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Model
{
  public  class Users
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        ObservableCollection<task_book> Tasks { get; set; }

    }
}
