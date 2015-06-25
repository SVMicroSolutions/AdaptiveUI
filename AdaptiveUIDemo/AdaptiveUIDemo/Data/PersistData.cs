using System;
using Newtonsoft.Json;
using System.IO;
using AdaptiveUIDemo.Interfaces;

namespace AdaptiveUIDemo.Data  
{
    public class PersistData : IPersistData
    {
        private const string FILE_PATH = @"C:\AdaptiveUIDemo\";
        public DataPersistance LoadData(string userName )
        {
			string fileSpec = CreateFileSpec(userName);

			FileInfo fi = new FileInfo(fileSpec);
			if (!fi.Exists)
				throw new FileNotFoundException();

            using (StreamReader file = File.OpenText(fileSpec))
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
			string fileSpec = CreateFileSpec(data.UserName);
            File.WriteAllText(fileSpec, json);

        }

		private string CreateFileSpec(string userName)
		{
			string filename = string.Format("{0}.txt", userName);
			return Path.Combine(FILE_PATH, filename);
		}
	}
}
