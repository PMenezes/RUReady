using DomainModel.Enums;
using DomainModel.Implementations.Entities;
using FluentValidation;

namespace DomainModel.Validators.EntityValidators
{
    public class ProjectFeatureValidation : BaseFluentValidator<Feature, ValidationErrorCodes>
    {
        public ProjectFeatureValidation()
        {
            RuleFor(feature => feature.Name).Must(s => !string.IsNullOrEmpty(s));
        }
    }
}