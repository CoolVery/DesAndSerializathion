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
using CsvHelper;
using System.Globalization;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace serialization
{
    internal class SerializationData<T>
    {
        
        public bool StartSerialization(List<T> listPerson, string filePath)
        {
            Console.WriteLine("Укажите способ Сериализации данных");
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "Json":
                    WriteFileJson(listPerson,  filePath);
                    break;
                case "Xml":
                    WriteFileXml(listPerson, filePath);
                    break;
                case "Csv":
                    WriteCsvFile(listPerson, filePath);
                    break;
                case "Yaml":
                    WriteYamlFile(listPerson, filePath);
                    break;
                default:
                    Console.WriteLine("Введите верны формат");
                    break;
            }
            return true;
        }
        private bool WriteFileJson(List<T> listPerson, string filePath)
        {
            List<string> dataJson = new List<string>();
            string result = "";
            foreach (var person in listPerson)
            {
                result = JsonConvert.SerializeObject(person);
                dataJson.Add(result);
            }
            File.WriteAllLines(filePath, dataJson);
            return true;
        }
        private bool WriteFileXml(List<T> listPerson, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, listPerson);
                fs.Close();
            }
            return true;
        }
        private bool WriteCsvFile(List<T> listPerson, string filePath)
        {
            using var file = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(file) ;
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<T>();
            csv.NextRecord();

            foreach(var person in listPerson)
            {
                csv.WriteRecord(person);
                csv.NextRecord();
            }
            return true;
        }
        private bool WriteYamlFile(List<T> listPerson, string filePath)
        {
            var yamlseril = new SerializerBuilder().Build();
            var yaml = yamlseril.Serialize(listPerson);
            File.WriteAllText(filePath, yaml);
            Console.WriteLine(yaml);
            return true;
        }
    }
}
