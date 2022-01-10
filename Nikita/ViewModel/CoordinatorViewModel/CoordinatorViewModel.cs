﻿using Nikita.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Nikita.ViewModel.CoordinatorViewModel
{
   public class CoordinatorViewModel:Base.BaseViewModel
    {
        private ObservableCollection<Model.task_book> NewTask;
        private SqlTableDependency<task_book> dep;
        public ObservableCollection<Model.task_book> newTask { get => NewTask; set { NewTask = value; OnPropertyChanged(nameof(newTask)); } }
        private Model.ConnectionDataBase _con;

        public CoordinatorViewModel()
        {
            _con = new ConnectionDataBase();
            Start();
        }
        public void Start()
        {

            var mapper = new ModelToTableMapper<task_book>();
            mapper.AddMapping(c => c.Number, "Number");
            mapper.AddMapping(c => c.start_date, "start_date");


            dep = new SqlTableDependency<task_book>(_con.sqlConnectionString, "task_book", mapper: mapper);

            if (dep.Status != TableDependency.SqlClient.Base.Enums.TableDependencyStatus.Starting)
            {
                //MessageBox.Show("d");
                dep.OnChanged += Changed;
                dep.Start();
            }

            //Console.WriteLine("Press a key to exit");
            //task_Books = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList())


        }
        ~CoordinatorViewModel()
        {
            dep.Stop();
        }
        /// <summary>
        /// Сделать для отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Changed(object sender, RecordChangedEventArgs<task_book> e)
        {
            //var changedEntity = e.Entity;
            //NewTask = new ObservableCollection<task_book>(new Model.CrudOp.CrudOperations().GetEntityList());
            if (e.Entity.executor == Staff.Name)
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    NewTask.Add(e.Entity);
                });
            }
            //MessageBox.Show(e.Entity.executor);
            OnPropertyChanged("newTask");


        }
    }
}