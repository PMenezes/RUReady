using Models;
using Repositories.Enums;

namespace Repositories.Validators.EntityValidators
{
    public class DareValidation : BaseFluentValidator<Dare, ValidationErrorCodes>
    {
        public DareValidation()
        {
        }
    }
}
