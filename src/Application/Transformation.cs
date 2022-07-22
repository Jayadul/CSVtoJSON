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

        #region constructor
        public Validation _validation;
        public Transformation(Validation validation)
        {
            _validation = validation;
        }
        #region

        public string Transform()
        {
            string result = ConvertCsvFileToJsonObject(csvFilePath);
            if (_validation.FileExists(jsonFilePath))
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
            bool isValidObject;
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

                //if object is valid, add to the list
                isValidObject = _validation.IsValidObject(objResult);
                if(isValidObject)
                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

        
        /// <summary>
        /// Save json object to the given file path
        /// </summary>
        /// <param name="jsonResult"></param>
        /// <param name="filePath"></param>
        public void SaveJson(string jsonResult,string filePath)
        {
            File.WriteAllText(filePath, jsonResult);
        }
    }
}

