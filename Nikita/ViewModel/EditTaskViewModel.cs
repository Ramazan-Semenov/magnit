using Nikita.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nikita.ViewModel
{
    class EditTaskViewModel:Base.BaseViewModel
    {
        public Model.task_book Task_Book { get; set; }

        public EditTaskViewModel(task_book _Book)
        {
            Task_Book = _Book;
            Update = new Controls.LambdaCommand(OnGetCommandExecuteUpdate, CanGetCommandExecuteUpdate);
        }
        public EditTaskViewModel()
        {
            Task_Book = new Model.task_book();

        }

        public ICommand Update { get; set; }
        private bool CanGetCommandExecuteUpdate(object param) => true;
        private void OnGetCommandExecuteUpdate(object param)
        {
            if (Task_Book != null)
            {
                MessageBox.Show("Ok");
                Model.CrudOp.CrudOperations crudOperations = new Model.CrudOp.CrudOperations();
                crudOperations.Update(Task_Book);
                //Views.Windows.EditTask edit = new Views.Windows.EditTask(Selected);
                //edit.Show();

            }
            else
            {
                MessageBox.Show("Не выбрана");
            }
        }

    }
}
