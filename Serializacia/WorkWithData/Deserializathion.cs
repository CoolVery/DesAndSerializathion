using CsvHelper;
using System.Globalization;
using System.Text.Json;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace Serializacia.WorkWithData
{
    internal class DeserializathionDate<T>
    {
        public List<T> StartDeserialization(string filePath)
        {
            

                
            List<T> resultList = new List<T>();
            string typeFile = filePath.Substring(filePath.IndexOf('.'));

            switch (typeFile)
            {
                case ".json":
                    resultList = ReadFileJson(filePath);
                    Console.WriteLine($"Данные удачно десериализованы из файл с именем {filePath}");
                    break;
                case ".xml":
                    resultList = ReadFileXml(filePath);
                    Console.WriteLine($"Данные удачно десериализованы из файл с именем {filePath}");
                    break;
                case ".csv":
                    resultList = ReadFileCsv(filePath);
                    Console.WriteLine($"Данные удачно десериализованы из файл с именем {filePath}");
                    break;
                case ".yaml":
                    resultList = ReadFileYaml(filePath);
                    Console.WriteLine($"Данные удачно десериализованы из файл с именем {filePath}");
                    break;
                default:
                    Console.WriteLine("Введите верный формат");
                    break;
            }
            return resultList;
        }
        private List<T> ReadFileJson(string filePath)
        {
            List<T>listDate = new List<T>();
            string dataJson = "";
            dataJson = File.ReadAllText(filePath);
            if (dataJson.Contains("["))
            {
                listDate = JsonSerializer.Deserialize<List<T>>(dataJson);
            }
            else
            {
                var strData = JsonSerializer.Deserialize<T>(dataJson);
                listDate.Add(strData);
            }

            return listDate;
        }
        private List<T> ReadFileXml(string filePath)
        {
            List<T> listDate = new List<T>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                listDate = (List<T>)xmlSerializer.Deserialize(fs);
            }
            return listDate;
        }
        private List<T> ReadFileCsv(string filePath)
        {
            List<T> listDate;
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            listDate = csv.GetRecords<T>().ToList();

            return listDate;
        }
        private List<T> ReadFileYaml(string filePath)
        {
            string text = File.ReadAllText(filePath);
            var deserializer = new DeserializerBuilder().Build();
            List<T> deserialData = deserializer.Deserialize<List<T>>(text);
            List<T> listDate = deserialData;
            return listDate;
        }
    }
}
