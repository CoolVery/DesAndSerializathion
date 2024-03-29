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
                Console.WriteLine("Выберите действие, которое хотите выполнить:\n1. Записать людей в базу\n2. Сериализовать данные людей\n3. Десериализовать и получить данные людей");
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
                        Console.WriteLine("Укажите способ Сериализации данных");
                        string choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "Json":
                                SerializationData<JsonSerializer> serializationDataJson = new SerializationData<JsonSerializer>();
                                serializationDataJson.StartSerialization(listPerson, filePath);
                                break;
                            case "Xml":
                                SerializationData<XmlSerializer> serializationDataXml = new SerializationData<XmlSerializer>();
                                serializationDataXml.StartSerialization(listPerson, filePath);
                                break;
                            default:
                                Console.WriteLine("Введите верны формат");
                                break;
                        }
                        Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                        break;
                    case "3":
                        Console.WriteLine("Задайте имя файла, из которого будут десериализоваться файлы");
                        string filePathDec = Console.ReadLine();
                        Console.WriteLine("Укажите способ Десериализации данных");
                        string choiseDec = Console.ReadLine();
                        switch (choiseDec)
                        {
                            case "Json":
                                SerializationData<JsonSerializer> deserializationDataJson = new SerializationData<JsonSerializer>();
                                deserializationDataJson.StartDeserialization(filePathDec);
                                break;
                            case "Xml":
                                SerializationData<XmlSerializer> deserializationDataXml = new SerializationData<XmlSerializer>();
                                deserializationDataXml.StartDeserialization(filePathDec);
                                break;
                        }
                        break;
                }
            }
            

        }
    }
}