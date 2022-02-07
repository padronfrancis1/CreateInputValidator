using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IServiceValidateable
    {
        IValidationService ValidationService { get; set; }
    }
}
