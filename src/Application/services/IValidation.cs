using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    public interface IValidation
    {
        public bool FileExists(string fileFullPath);
        public bool IsValidObject(IDictionary<string, string> objResult);

    }
}
