using System;
using Newtonsoft.Json;
using System.IO;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.Data  
{
    class PesistData : IPersistData
    {
        private const string FILE_PATH = @"C:\AdaptiveUIDemo\Data.txt";
        public DataPersistance LoadData()
        {
            using (StreamReader file = File.OpenText(FILE_PATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                DataPersistance data = (DataPersistance)serializer.Deserialize(file, typeof(DataPersistance));
                return data;
            }
        }

        public void SaveData(DataPersistance data)
        {

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(FILE_PATH, json);

        }
    }
}
