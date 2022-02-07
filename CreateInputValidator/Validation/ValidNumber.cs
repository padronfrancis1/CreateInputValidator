using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Validators
{
    public class ValidNumber : ValidationAttribute
    {
        private int _allowedNumber;

        // Custom Validations 
        public ValidNumber(int allowedNumber)
        {
            _allowedNumber = allowedNumber;
        }

        public override bool IsValid(object value)
        {
            var condition = (5 == (int)value);
            return condition;
        }
    }
}
