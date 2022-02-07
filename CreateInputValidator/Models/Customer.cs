using DomainModel.Validators;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Customer : DomainObject, IServiceValidateable
    {
        public Customer()
        {
        }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        public IValidationService ValidationService { get; set; }

        public override IInputValidator CreateInputValidator()
        {
            return new InputValidator<Customer>(this);
        }

    }
}
