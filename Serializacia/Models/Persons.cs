using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Serializacia.Models
{

    public class PersonsData
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

        public static List<PersonsData> InputDateInList(int countPersons)
        {
            
                List<PersonsData> listPerson = new List<PersonsData>();
            try
            {
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
            catch
            {
                Console.WriteLine("В возраст человека надо записывать Цифру");
                return listPerson;
            }
        }
        public static void PrintList(IEnumerable<PersonsData> listPerson)
        {
            int countPersons = 1;
            foreach (var perosn in listPerson)
            {
                Console.WriteLine($"Информация человека под номером - {countPersons}");
                Console.WriteLine($"Имя - {perosn.Name}");
                Console.WriteLine($"Фамилия - {perosn.SecondName}");
                Console.WriteLine($"Отчество - {perosn.Patronymic}");
                Console.WriteLine($"Возраст - {perosn.Age}");
                countPersons++;
            }
        }
    }

}
