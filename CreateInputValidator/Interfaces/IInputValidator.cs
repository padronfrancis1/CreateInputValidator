using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IInputValidator
    {
        ICollection<string> GetAllErrors();
        Dictionary<string, string> GetErrorDictionary();
        string Validate(string columnName);
        IEnumerable GetErrors(string propertName);
    }
}
