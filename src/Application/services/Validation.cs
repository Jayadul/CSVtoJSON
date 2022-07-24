namespace Application.services
{
    public class Validation: IValidation
    {
        /// <summary>
        /// Check if the file exists where trying to save data
        /// </summary>
        /// <param name="fileFullPath"></param>
        /// <returns></returns>
        public bool FileExists(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Check object validity
        /// </summary>
        /// <param name="objResult"></param>
        /// <returns></returns>
        public bool IsValidObject(IDictionary<string, string> objResult)
        {
            bool isValid = true;
            //if any value of the object is null, return false
            bool containsNullValue = objResult.Values.Any(s => s == null);
            if(containsNullValue)
                return false;

            //ID validation; If ID is a number
            string Id;
            objResult.TryGetValue("id", out Id);
            var IdIsANumber = IsANumber(Id);
            if(!IdIsANumber) return false;

            //Age validation; If Age is a number and less than 44
            string Age;
            objResult.TryGetValue("age", out Age);
            var AgeIsANumber = IsANumber(Age);
            if (AgeIsANumber) isValid = AgeIsLessThan44(Age);

            return isValid;
        }

        private bool IsANumber(string value)
        {
            var isNumeric = int.TryParse(value, out int n);
            return isNumeric;
        }

        private bool AgeIsLessThan44(string value)
        {
            return Convert.ToInt32(value) <44?true:false;
        }
    }
}
