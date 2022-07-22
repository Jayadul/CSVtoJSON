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
    }
}
