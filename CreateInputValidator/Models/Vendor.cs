using DomainModel.Validators;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Vendor : DomainObject
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public Vendor()
        {

        }
        public override IInputValidator CreateInputValidator()
        {
            return new InputValidator<Vendor>(this);
        }
    }
}
