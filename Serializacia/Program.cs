using Newtonsoft.Json;
using serialization;
using System.Xml.Serialization;

namespace Serializacia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!");
            bool exit = true;
            List<PersonsData> listPerson = new List<PersonsData>();
            while (exit) 
            {
                Console.WriteLine("Выберите действие, которое хотите выполнить:\n1. Записать людей в базу\n2. Сериализовать данные людей\n3. Десериализовать и получить данные людей\n" +
                    "4. Вывести информацию");
                string choiseAction = Console.ReadLine();
                switch (choiseAction)
                {
                    case "1":
                        Console.WriteLine("Введите количество людей в базе");
                        int countPerson = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < countPerson; i++)
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
                        Console.WriteLine("Все пользователи добавлены в базу");
                    break;
                    case "2":
                        if (listPerson.Count == 0)
                        {
                            Console.WriteLine("Вы не добавили данные в базу. Для добавления данных в базу надо выбрать действие 1");
                            break;
                        }
                        Console.WriteLine("Задайте имя файла, в котором будет сохраняться сериализованны данные и откуда они будут считываться (Укажите формат файла, т.е <Имя файла>.<Формат файла>)");
                        string filePath = Console.ReadLine();
                        SerializationData<PersonsData> dataPerosonsSerial = new SerializationData<PersonsData>();
                        dataPerosonsSerial.StartSerialization(listPerson, filePath);
                        Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                        break;
                    case "3":
                        Console.WriteLine("Задайте имя файла, из которого будут десериализоваться файлы");
                        string filePathDec = Console.ReadLine();
                        List<PersonsData> resultList = new List<PersonsData>();
                        DeserializathionDate<PersonsData> dataPerosonsDeserial = new DeserializathionDate<PersonsData>();
                        resultList = dataPerosonsDeserial.StartDeserialization(filePathDec);
                        
                        break;
                }
            }
            

        }
    }
}