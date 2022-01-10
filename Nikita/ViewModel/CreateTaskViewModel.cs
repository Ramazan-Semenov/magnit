using Microsoft.Win32;
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

        public string dep { get; set; } = "Развитие отчетности и разработки инстрементов";
        public List<string> listdep { get; set; } = new List<string>()
        { "Прогнозирование", "Развитие отчетности и разработки инстрементов","Аналитика" };
        public CreateTaskViewModel()
        {
            Create = new Controls.LambdaCommand(OnGetCommandExecuteCreate,CanGetCommandExecuteCreate);
            openfloderfile = new Controls.LambdaCommand(OnGetCommandExecuteopenfloderfile, CanGetCommandExecuteopenfloderfile);
            Task_Book = new Model.task_book();
        }
        /// <summary>
        /// Улучшить условие, я уже спать хочу
        /// </summary>
        /// <param name="__task_Book"></param>
        public CreateTaskViewModel(Model.task_book __task_Book)
        {
            if (__task_Book==null)
            {
                __task_Book = new Model.task_book();
            }
            __task_Book.status = string.Empty;
            Create = new Controls.LambdaCommand(OnGetCommandExecuteCreate, CanGetCommandExecuteCreate);
            openfloderfile = new Controls.LambdaCommand(OnGetCommandExecuteopenfloderfile, CanGetCommandExecuteopenfloderfile);
            Task_Book = new Model.task_book();
            Task_Book = __task_Book;
        }
        
        public ICommand openfloderfile { get; set; }
        private bool CanGetCommandExecuteopenfloderfile(object param) => true;
        private void OnGetCommandExecuteopenfloderfile(object param)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()== true)
            {
                MessageBox.Show(openFile.SafeFileName);
            }   

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
