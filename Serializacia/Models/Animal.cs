using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacia.Models
{
    internal class Animal
    {
        public string TypeAnimal { get; set; }
        public string Color { get; set; }
        public string TypeEat { get; set; }
        public int Age { get; set; }

        public static List<Animal> InputDateInList(int countAnimal)
        {

            List<Animal> listAnimal = new List<Animal>();
            try
            {
                for (int i = 0; i < countAnimal; i++)
                {
                    Animal animal = new Animal();
                    Console.WriteLine("Введите Тип животного под номером - " + i);
                    animal.TypeAnimal = Console.ReadLine();
                    Console.WriteLine("Введите Цвет животного под номером - " + i);
                    animal.Color = Console.ReadLine();
                    Console.WriteLine("Введите Тип питания животного под номером - " + i);
                    animal.TypeEat = Console.ReadLine();
                    Console.WriteLine("Введите Возраст животного под номером - " + i);
                    animal.Age = Convert.ToInt32(Console.ReadLine());
                    listAnimal.Add(animal);
                }
                return listAnimal;
            }
            catch
            {
                Console.WriteLine("В возраст животного надо записывать Цифру");
                return listAnimal;
            }
        }
        public static void PrintList(IEnumerable<Animal> listAnimal)
        {
            int countAnimal = 1;
            foreach (var animal in listAnimal)
            {
                Console.WriteLine($"Информация животного под номером - {countAnimal}");
                Console.WriteLine($"Тип - {animal.TypeAnimal}");
                Console.WriteLine($"Цвет - {animal.Color}");
                Console.WriteLine($"Тип питания - {animal.TypeEat}");
                Console.WriteLine($"Возраст - {animal.Age}");
            }
        }
    }
}
