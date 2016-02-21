using DomainModel.Enums;
using DomainModel.Implementations.Entities;
using FluentValidation;

namespace DomainModel.Validators.EntityValidators
{
    internal class ProjectValidation : BaseFluentValidator<Project, ValidationErrorCodes>
    {
        public ProjectValidation()
        {
            RuleFor(project => project.Name).Must(s => !string.IsNullOrEmpty(s));
        }
    }
}