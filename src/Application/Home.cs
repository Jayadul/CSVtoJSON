﻿using Application.services;
using Newtonsoft.Json;

namespace Application
{
    public class Home
    {
        #region global variables
        static string filePath = Environment.CurrentDirectory + @"\..\..\..\files";
        static string csvFileName = "test.csv";
        static string csvFilePath = Path.Combine(filePath, csvFileName);
        static string jsonFilePath = Path.ChangeExtension(csvFilePath, ".json");
        #endregion

        #region constructor
        public IValidation _validation;
        public Home(IValidation validation)
        {
            _validation = validation;

        }
        #endregion

        //Base function of the application
        public string Convert()
        {
            string result = ConvertCsvFileToJsonObject(csvFilePath);

            // Create the file and use streamWriter to write text to it.
            //If the file existence is not check, this will overwrite said file.
            //Use the using block so the file can close and vairable disposed correctly
            if (!File.Exists(jsonFilePath))
                using (StreamWriter writer = File.CreateText(jsonFilePath)) { writer.Write(result); }
            else
                SaveJson(result, jsonFilePath);

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
                for (int j = 0; j < 3; j++)
                    objResult.Add(properties[j], csv[i][j]);

                
                //if object is valid, transform name and add to the list
                isValidObject = _validation.IsValidObject(objResult);
                if (isValidObject)
                {
                    objResult["name"] = Transformation.ToSankeCase(objResult["name"]);
                    Transformation.RenameKey(objResult, "id", "num");
                    Transformation.RenameKey(objResult, "name", "description");
                    Transformation.RenameKey(objResult, "age", "years");
                    
                    listObjResult.Add(objResult);
                }               
            }

            return JsonConvert.SerializeObject(listObjResult);
        }


        /// <summary>
        /// Save json object to the given file path
        /// </summary>
        /// <param name="jsonResult"></param>
        /// <param name="filePath"></param>
        public void SaveJson(string jsonResult, string filePath)
        {
            File.WriteAllText(filePath, jsonResult);
        }
    }
}
