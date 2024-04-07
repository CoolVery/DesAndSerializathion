using Newtonsoft.Json;
using Serializacia.FolderMainMethod;
using Serializacia.Models;
using Serializacia.WorkWithData;
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
            List<PersonsData> listPersonFromFile = new List<PersonsData>();
            List<Animal> listAnimalFromFile = new List<Animal>();
            while (exit)
            {
                Console.WriteLine("Выберите действие, которое хотите выполнить:\n1. Записать данные в базу\n2. Сериализовать данные людей\n3. Десериализовать и получить данные людей\n" +
                    "4. Вывести информацию\n5. Выйти из программы(Вводите номер выбора)");
                string choiseAction = Console.ReadLine();
                switch (choiseAction)
                {
                    case "1":
                        MainMethodsWorksWithModels.InputDateInBase(ref listPerson, ref listAnimal);                       
                        break;
                    case "2":
                        MainMethodsWorksWithModels.InputDateInFile(listPerson, listAnimal);
                        break;
                    case "3":
                        Console.WriteLine("В какую базу вы хотите записать данные из файла?\n1. Люди\n2. Животные\n(Вводите номер выбора)");
                        string baseChoise = Console.ReadLine();
                        switch(baseChoise)
                        {
                            case "1":
                                listPersonFromFile =  MainMethodsWorksWithModels.RecordDataInBaseFromFile<PersonsData>();
                                break;
                            case "2":
                                listAnimalFromFile = MainMethodsWorksWithModels.RecordDataInBaseFromFile<Animal>();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректную базу. Внимательно читайте список доступных баз");
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Из какой базы вы хотите вывести данные?\n1. Люди\n2. Животные\n(Вводите номер выбора)");
                        string choise = Console.ReadLine();
                        switch(choise)
                        {
                            case "1":
                                MainMethodsWorksWithModels.OutputDateFromBaseToConsole(listPersonFromFile, listAnimalFromFile, choise);
                                break;
                            case "2":
                                MainMethodsWorksWithModels.OutputDateFromBaseToConsole(listPersonFromFile, listAnimalFromFile, choise);
                                break;
                        }
                        break;
                    case "5":
                        exit = false;
                        Console.WriteLine("Всего хорошего");
                        break;
                    default:
                        Console.WriteLine("Вы ввели неверный номер дейсвия - читайте внимательно список доступных действий");
                        break;

                }
            }
        }
    }
}