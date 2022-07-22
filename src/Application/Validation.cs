using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Validation
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
            //if any value of the object is null, return false
            bool containsNullValue = objResult.Values.Any(s => s == null);
            if(containsNullValue)
                return false;

            string Id;
            bool hasIdValue = false;

            //convert id is not int, return false
            hasIdValue = objResult.TryGetValue("id", out Id);
            try
            {
                Convert.ToInt32(Id);
            }
            catch (Exception)
            {
                return false;
            }  
            return true;
        }
    }
}
