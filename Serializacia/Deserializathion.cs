using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Serializacia
{
    internal class DeserializathionDate<T>
    {
        public List<T> StartDeserialization(string filePath)
        {
            List<T> resultList = new List<T>();
            Console.WriteLine("Укажите способ Десериализации данных");
            string choiseDec = Console.ReadLine();
            switch (choiseDec)
            {
                case "Json":
                    resultList = ReadFileJson(filePath);
                    break;
                case "Xml":
                    resultList = ReadFileXml(filePath);
                    break;
                case "Csv":
                    resultList = ReadFileCsv(filePath);
                    break;
                case "Yaml":
                    resultList = ReadFileYaml(filePath);
                    break;
            }
            return resultList;
        }
        private List<T> ReadFileJson(string filePath)
        {
            List<T> listDate = new List<T>();
            List<string> dataJson = new List<string>();
            StreamReader reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                dataJson.Add(reader.ReadLine());
            }
            foreach (var date in dataJson)
            {
                T? dateInFile = JsonConvert.DeserializeObject<T>(date);
                listDate.Add(dateInFile);
            }
            reader.Close();
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
