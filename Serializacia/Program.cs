using Newtonsoft.Json;
using serialization;
using System.ComponentModel;
using System.ComponentModel.Design;
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
            List<Animal> listAnimal = new List<Animal>();
            List<PersonsData> listPersonInFile = new List<PersonsData>();
            List<Animal> listAnimalInFile = new List<Animal>();
            while (exit)
            {
                Console.WriteLine("Выберите действие, которое хотите выполнить:\n1. Записать данные в базу\n2. Сериализовать данные людей\n3. Десериализовать и получить данные людей\n" +
                    "4. Вывести информацию");
                string choiseAction = Console.ReadLine();
                switch (choiseAction)
                {
                    case "1":
                        Console.WriteLine("Выберите базу, с которой вы хотите работать\n1. Люди\n2. Животные");
                        string baseChoise = Console.ReadLine();
                        switch (baseChoise)
                        {
                            case "Люди":
                                Console.WriteLine("Введите количество людей в базе");
                                int countPerson = Convert.ToInt32(Console.ReadLine());
                                listPerson = PersonsData.InputDateInList(countPerson);
                                break;
                            case "Животные":
                                Console.WriteLine("Введите количество животных в базе");
                                int countAnimal = Convert.ToInt32(Console.ReadLine());
                                listAnimal = Animal.InputDateInList(countAnimal);
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректную базу. Внимательно читайте список доступных баз"); 
                                break;
                        }
                        Console.WriteLine("Все пользователи добавлены в базу");
                        break;
                    case "2":
                        if (listPerson.Count == 0)
                        {
                            Console.WriteLine("Вы не добавили данные людей в базу. Для добавления данных в базу надо выбрать действие 1");
                            break;
                        }
                        else if (listAnimal.Count == 0)
                        {
                            Console.WriteLine("Вы не добавили данные животных в базу. Для добавления данных в базу надо выбрать действие 1");
                            break;
                        }
                        Console.WriteLine("Какую базу хотите записать?\n1. Люди\n2. Животные");
                        baseChoise = Console.ReadLine();
                        switch (baseChoise)
                        {
                            case "Люди":
                                Console.WriteLine("Задайте имя файла, в котором будет сохраняться сериализованны данные и откуда они будут считываться (Укажите формат файла, т.е <Имя файла>.<Формат файла>)");
                                string filePath = Console.ReadLine();
                                SerializationData<PersonsData> dataPerosonsSerial = new SerializationData<PersonsData>();
                                dataPerosonsSerial.StartSerialization(listPerson, filePath);
                                Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                                break;
                            case "Животные":
                                Console.WriteLine("Задайте имя файла, в котором будет сохраняться сериализованны данные и откуда они будут считываться (Укажите формат файла, т.е <Имя файла>.<Формат файла>)");
                                filePath = Console.ReadLine();
                                SerializationData<Animal> dataAnimalssSerial = new SerializationData<Animal>();
                                dataAnimalssSerial.StartSerialization(listAnimal, filePath);
                                Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректную базу. Внимательно читайте список доступных баз");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("В какую базу вы хотите записать данные из файла?\n1. Люди\n2. Животные");
                        baseChoise = Console.ReadLine();
                        switch(baseChoise)
                        {
                            case "Люди":
                                Console.WriteLine("Задайте имя файла, из которого будут десериализоваться файлы");
                                string filePathDec = Console.ReadLine();
                                DeserializathionDate<PersonsData> dataPerosonsDeserial = new DeserializathionDate<PersonsData>();
                                listPersonInFile = dataPerosonsDeserial.StartDeserialization(filePathDec);
                                break;
                            case "Животные":
                                Console.WriteLine("Задайте имя файла, из которого будут десериализоваться файлы");
                                filePathDec = Console.ReadLine();
                                DeserializathionDate<Animal> dataAnimalsDeserial = new DeserializathionDate<Animal>();
                                listAnimalInFile = dataAnimalsDeserial.StartDeserialization(filePathDec);
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректную базу. Внимательно читайте список доступных баз");
                                break;
                        }
                        break;
                    case "4":
                        PersonsData.PrintList(listPersonInFile);
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверный номер дейсвия - читайте внимательно список доступных действий");
                        break;

                }
            }
        }
    }
}