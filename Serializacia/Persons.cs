using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Serializacia
{

    public class PersonsData
    {      
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get ; set; }

        public static List<PersonsData> InputDateInList(int countPersons)
        {
            List<PersonsData> listPerson = new List<PersonsData>();

            for (int i = 0; i < countPersons; i++)
            {
                PersonsData person = new PersonsData();
                Console.WriteLine("Введите Имя человека под номером - " + i);
                person.Name = Console.ReadLine();
                Console.WriteLine("Введите Фамилию человека под номером - " + i);
                person.SecondName = Console.ReadLine();
                Console.WriteLine("Введите Отчество человека под номером - " + i);
                person.Patronymic = Console.ReadLine();
                Console.WriteLine("Введите Возраст человека под номером - " + i);
                person.Age = Convert.ToInt32(Console.ReadLine());
                listPerson.Add(person);
            }
            return listPerson;
        } 
        public static void PrintList(List<PersonsData> listPerson)
        {
            foreach (var item in listPerson)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SecondName);
                Console.WriteLine(item.Patronymic);
                Console.WriteLine(item.Age);

            }
        }
    }

}
