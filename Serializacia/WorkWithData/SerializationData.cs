using System.Xml.Serialization;
using CsvHelper;
using System.Globalization;
using YamlDotNet.Serialization;
using System.Text.Json;

namespace Serializacia.WorkWithData
{
    internal class SerializationData<T>
    {

        public bool StartSerialization(List<T> listDate, string filePath)
        {
            string typeFile = filePath.Substring(filePath.IndexOf('.'));

            switch (typeFile)
            {
                case ".json":
                    WriteFileJson(listDate, filePath);
                    Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                    break;
                case ".xml":
                    WriteFileXml(listDate, filePath);
                    Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                    break;
                case ".csv":
                    WriteCsvFile(listDate, filePath);
                    Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                    break;
                case ".yaml":
                    WriteYamlFile(listDate, filePath);
                    Console.WriteLine($"Данные удачно сериализованы в файл с именем {filePath}");
                    break;
                default:
                    Console.WriteLine("Введите верны формат");
                    break;
            }
            return true;
        }
        private bool WriteFileJson(List<T> listPerson, string filePath)
        {
            using (FileStream file = new FileStream(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(file, listPerson);
            }
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
            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteHeader<T>();
            csv.NextRecord();

            foreach (var person in listPerson)
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
