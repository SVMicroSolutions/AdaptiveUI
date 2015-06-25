using System;
using Newtonsoft.Json;
using System.IO;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.Data  
{
    public class PersistData : IPersistData
    {
        private const string FILE_PATH = @"C:\AdaptiveUIDemo\";
        private const string FILE_NAME = @"Data.txt";
        private string fullpath = Path.Combine(FILE_PATH, FILE_NAME);
        public DataPersistance LoadData()
        {

            using (StreamReader file = File.OpenText(fullpath))
            {
                JsonSerializer serializer = new JsonSerializer();
                DataPersistance data = (DataPersistance)serializer.Deserialize(file, typeof(DataPersistance));
                return data;
            }

        }

        public void SaveData(DataPersistance data)
        {

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            if (Directory.Exists(FILE_PATH) != true)
            {
                Directory.CreateDirectory(FILE_PATH);
            }
            File.WriteAllText(fullpath, json);

        }
    }
}
