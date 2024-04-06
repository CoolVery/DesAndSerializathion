using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializacia
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
    }
}
