using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Serializacia
{
    public class PersonsData
    {

        private string name;
        private string secondName;
        private string patronymic;
        private int age;

        public string Name { get => name; set => name = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string Patronymic { get => patronymic; set => patronymic = value; }
        public int Age { get => age; set => age = value; }

        
        
    }

}
