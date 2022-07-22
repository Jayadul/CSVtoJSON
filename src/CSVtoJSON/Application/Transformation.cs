using Newtonsoft.Json;

namespace Application
{
    public class Transformation
    {

        /// <summary>
        /// Read CSV file from given path & convert it to JSON
        /// </summary>
        /// <returns>JSON Object</returns>
        public string ConvertCsvFileToJsonObject(string path)
        {
            
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
                csv.Add(line.Split(';'));

            var properties = lines[0].Split(';');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

        public string JsonFilePath(string fileFullPath)
        {
            FileInfo fileInfo = new FileInfo(fileFullPath);

            if (!fileInfo.Exists)
                Directory.CreateDirectory(fileInfo.Directory.FullName);
            return fileInfo.FullName;
        }
    }
}

