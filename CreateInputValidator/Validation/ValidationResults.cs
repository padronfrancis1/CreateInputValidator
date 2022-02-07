using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateInputValidator.Validation
{
    public class ValidationResults
    {
        public List<string> GetAllErrors { get; set; }
        public ValidationResults()
        {
            GetAllErrors = new List<string>();
        }

        public ValidationResults(IInputValidator inputValidator)
        {
            GetAllErrors = inputValidator.GetAllErrors().ToList();
        }

        public virtual bool IsValid
        {
            get
            {
                return GetAllErrors.Count == 0;
            }
        }
    }
}
