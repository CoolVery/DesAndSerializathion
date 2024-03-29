using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Serializacia;
using System.Xml.Serialization;

namespace serialization
{
    internal class SerializationData<T>
    {
        
        public bool StartSerialization(List<PersonsData> listPerson, string filePath)
        {
            if (typeof(T) == typeof(Newtonsoft.Json.JsonSerializer))
            {
                List<string> dataJson = new List<string>();
                string result = "";
                foreach (var person in listPerson)
                {
                    result = JsonConvert.SerializeObject(person);
                    dataJson.Add(result);
                }
                File.WriteAllLines(filePath, dataJson);
            }
            else if (typeof(T) == typeof(XmlSerializer))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PersonsData>));
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, listPerson);
                    fs.Close();
                }
            }
  
            return true;
        }
        public List<PersonsData> StartDeserialization(string filePath)
        {
            List<PersonsData> personList= new List<PersonsData>();
            if (typeof(T) == typeof(Newtonsoft.Json.JsonSerializer))
            {
                List<string> dataJson = new List<string>();
                StreamReader reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    dataJson.Add(reader.ReadLine());
                }
                reader.Close();
                foreach (var pers in dataJson)
                {
                    PersonsData? person = JsonConvert.DeserializeObject<PersonsData>(pers);
                    personList.Add(person);
                    Console.WriteLine($"Данные пользователя: {person.Name} {person.SecondName} {person.Patronymic} {person.Age}");
                }
            }
            else if (typeof(T) == typeof(XmlSerializer))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonsData));
                using (StreamReader fs = new StreamReader(filePath))
                {
                    PersonsData? person = xmlSerializer.Deserialize(fs) as PersonsData;
                    Console.WriteLine($"Name: {person?.Name}  Age: {person?.Age}");
                }

            }

            return personList;
        }
    }
}
