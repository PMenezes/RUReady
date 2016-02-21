using DomainModel.Enums;
using DomainModel.Implementations.Entities;
using FluentValidation;

namespace DomainModel.Validators.EntityValidators
{
    public class UserValidation : BaseFluentValidator<User, ValidationErrorCodes>
    {
        public UserValidation()
        {
            RuleFor(user => user.UserName).Must(s => !string.IsNullOrEmpty(s));
            RuleFor(user => user.Password).Must(s => !string.IsNullOrEmpty(s) && s.Length > 6);
        }
    }
}