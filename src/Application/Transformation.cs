using Newtonsoft.Json;

namespace Application
{
    public class Transformation
    {
        #region global variables
        static string csvFileName = "test.csv";
        static string jsonFileName = "test.json";
        string csvFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\files", csvFileName);
        string jsonFilePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\files", jsonFileName);
        #endregion

        public string Transform()
        {
            string result = ConvertCsvFileToJsonObject(csvFilePath);
            var validation = new Validation();
            if (validation.FileExists(jsonFilePath))
            {
                SaveJson(result, jsonFilePath);
            }
            return result;
        }

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

        
        /// <summary>
        /// save json object to the given file path
        /// </summary>
        /// <param name="jsonResult"></param>
        /// <param name="filePath"></param>
        public void SaveJson(string jsonResult,string filePath)
        {
            File.WriteAllText(filePath, jsonResult);
        }
    }
}

