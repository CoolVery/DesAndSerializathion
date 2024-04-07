
using Serializacia.Models;
using Serializacia.WorkWithData;

namespace Serializacia.FolderMainMethod
{
    internal class MainMethodsWorksWithModels
    {
        const string directory = @"files\";
        public static void InputDateInBase(ref List<PersonsData> listPerson, ref List<Animal> listAnimal)
        {
            Console.WriteLine("Выберите базу, с которой вы хотите работать\n1. Люди\n2. Животные\n(Вводите номер выбора)");
            string baseChoise = Console.ReadLine();
            switch (baseChoise)
            {
                case "1":
                    Console.WriteLine("Введите количество людей в базе");
                    int countPerson = Convert.ToInt32(Console.ReadLine());
                    listPerson = PersonsData.InputDateInList(countPerson);
                    break;
                case "2":
                    Console.WriteLine("Введите количество животных в базе");
                    int countAnimal = Convert.ToInt32(Console.ReadLine());
                    listAnimal = Animal.InputDateInList(countAnimal);
                    break;
                default:
                    Console.WriteLine("Вы ввели некорректную базу. Внимательно читайте список доступных баз");
                    break;
            }
        }
        public static void InputDateInFile(List<PersonsData> listPerson, List<Animal> listAnimal)
        {
            Console.WriteLine("Какую базу хотите записать?\n1. Люди\n2. Животные\n(Вводите номер выбора)");
            string baseChoise = Console.ReadLine();
            switch (baseChoise)
            {
                case "1":
                    if (listPerson.Count == 0)
                    {
                        Console.WriteLine("Вы не добавили данные людей в базу. Для добавления данных в базу надо выбрать действие 1");
                        return;
                    }
                    Console.WriteLine("Задайте имя файла, в котором будет сохраняться сериализованны данные и откуда они будут считываться (Укажите формат файла, т.е <Имя файла>.<Формат файла>)");
                    string filePath = Console.ReadLine();
                    string stopSymbol = "\\/:*?\"<>|";
                    if(filePath.Any(stopSymbol.Contains))
                    {
                        Console.WriteLine("Имя файла не может содержать символы " + stopSymbol);
                        return;
                    }
                    SerializationData<PersonsData> dataPerosonsSerial = new SerializationData<PersonsData>();
                    dataPerosonsSerial.StartSerialization(listPerson, directory + filePath);
                    break;
                case "2":
                    if (listAnimal.Count == 0)
                    {
                        Console.WriteLine("Вы не добавили данные животных в базу. Для добавления данных в базу надо выбрать действие 1");
                        return;
                    }
                    Console.WriteLine("Задайте имя файла, в котором будет сохраняться сериализованны данные и откуда они будут считываться (Укажите формат файла, т.е <Имя файла>.<Формат файла>)");
                    filePath = directory + Console.ReadLine();
                    SerializationData<Animal> dataAnimalssSerial = new SerializationData<Animal>();
                    dataAnimalssSerial.StartSerialization(listAnimal, directory + filePath);
                    break;
                default:
                    Console.WriteLine("Вы ввели некорректную базу. Внимательно читайте список доступных баз");
                    break;
            }
        }
        public static List<T> RecordDataInBaseFromFile<T>()
        {
            List<T> listPersonFromFile = new List<T>();
            Console.WriteLine("Задайте имя файла, из которого будут десериализоваться файлы");
            string filePathDec = directory + Console.ReadLine();
            if(!File.Exists(filePathDec)) 
            {
                Console.WriteLine("Данного файла не существует, проверьте, что файл существует.");
                return listPersonFromFile;
            }
            DeserializathionDate<T> dataPerosonsDeserial = new DeserializathionDate<T>();
            listPersonFromFile = dataPerosonsDeserial.StartDeserialization(filePathDec);
            return listPersonFromFile;
        }
        public static void OutputDateFromBaseToConsole(List<PersonsData> listPerson, List<Animal> listAnimal, string baseData)
        {

            Console.WriteLine("В каком виде вы хотите вывести данные из базы?\n1. Без сортировки\n2. С сортировкой\n(Вводите номер выбора)");
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    if (baseData == "1")
                    {
                        PersonsData.PrintList(listPerson);
                    }
                    else if (baseData == "2")
                    {
                        Animal.PrintList(listAnimal);
                    }
                    break;
                case "2":
                    if (baseData == "1")
                    {
                        IEnumerable<PersonsData> query;
                        Console.WriteLine("По какому способу вы хотите сортировать?\n1. По Имени\n2. По Возрасту\n(Вводите номер выбора)");
                        choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                query = listPerson.OrderBy(person => person.Name);
                                PersonsData.PrintList(query);
                                break;

                            case "2":
                                query = listPerson.OrderBy(person => person.Age);
                                PersonsData.PrintList(query);
                                break;
                        }
                    }
                    else if (baseData == "2")
                    {
                        IEnumerable<Animal> query;
                        Console.WriteLine("По какому способу вы хотите сортировать?\n1. По Цвету\n2. По Возрасту\n(Вводите номер выбора)");
                        choise = Console.ReadLine();
                        switch (choise)
                        {
                            case "1":
                                query = listAnimal.OrderBy(animal => animal.Color);
                                Animal.PrintList(query);
                                break;

                            case "2":
                                query = listAnimal.OrderBy(animal => animal.Age);
                                Animal.PrintList(query);
                                break;
                        }
                    }
                    break;
            }
        }
    }
}
