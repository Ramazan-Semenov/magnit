using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nikita
{
  public class CreateTaskViewModel
    {

        public DateTime DateNow { get; set; } = DateTime.Now;
        public string User { get; set; } = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string desctription { get; set; }
        public Model.task_book Task_Book { get; set; }
        public string name_of_the_task { get; set; }

        public CreateTaskViewModel()
        {
            Create = new Controls.LambdaCommand(OnGetCommandExecuteCreate,CanGetCommandExecuteCreate);
            Task_Book = new Model.task_book();
        }


        public ICommand Create { get; }
        private bool CanGetCommandExecuteCreate(object param) => true;
        private void OnGetCommandExecuteCreate(object param)
        {
            Task_Book.from_whom = User;
            Task_Book.start_date = DateNow;
            Task_Book.Date_of_compilation = DateTime.Now;

            new Model.CrudOp.CrudOperations().Create(Task_Book);
                MessageBox.Show("Запись добавлена");         
        }

    }
}
