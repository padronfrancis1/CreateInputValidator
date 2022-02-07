using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class User: DomainObject
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public User()
        {

        }
        public override IInputValidator CreateInputValidator()
        {
            return new InputValidator<User>(this);
        }
    }
}
