using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita
{
    class ViewM
    {
       public ObservableCollection<task_book> Employes { get; set; }
        public ViewM()
        {
            Employes = new ObservableCollection<task_book>
{
    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="дрмиор", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" },
    new task_book{Numder=1, Date_of_compilation=DateTime.Parse("27/10/2021"),from_whom="Пинчук Наталья Александровна", task_type="Анализ", name_of_the_task="Проект 'Вертикальные теплицы'_Магнит_Краснодар", start_date=DateTime.Parse("27/10/2021"), end_date=DateTime.Parse("28/10/2021"), executor="Хахулина Юлия, Маланова Ольга", priority="Высокий", status="Принят" }

};
        }
    }
}
