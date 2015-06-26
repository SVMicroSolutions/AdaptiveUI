using System.IO;
using AdaptiveUIDemo.Interfaces;
using Newtonsoft.Json;

namespace AdaptiveUIDemo.Data
{
	public class PersistData : IPersistData
	{
		private const string FILE_PATH = @"C:\AdaptiveUIDemo\";

		public DataPersistance LoadData(string userName)
		{
			var fileSpec = CreateFileSpec(userName);
			var fInfo = new FileInfo(fileSpec);
			if (!fInfo.Exists)
				throw new FileNotFoundException();

			using (var file = File.OpenText(fileSpec))
			{
				var serializer = new JsonSerializer();
				var data = (DataPersistance) serializer.Deserialize(file, typeof (DataPersistance));

				return data;
			}
		}

		public void SaveData(DataPersistance data)
		{
			var json = JsonConvert.SerializeObject(data, Formatting.Indented);

			if (Directory.Exists(FILE_PATH) != true)
			{
				Directory.CreateDirectory(FILE_PATH);
			}
			var fileSpec = CreateFileSpec(data.UserName);

			// File.WriteAllText is supposed to overwrite existing file, but appears to be appending instead.
			// therefore, we want to delete the existing file before writing to it.
			var fInfo = new FileInfo(fileSpec);
			if (fInfo.Exists)
				fInfo.Delete();

			File.WriteAllText(fileSpec, json);
		}

		private static string CreateFileSpec(string userName)
		{
			var filename = $"{userName}.txt";
			return Path.Combine(FILE_PATH, filename);
		}
	}
}
