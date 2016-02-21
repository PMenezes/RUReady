using FluentValidation;
using System;
using System.Linq;

namespace Repositories.Validators
{
    public abstract class BaseFluentValidator<T, TValidationErrorCodeEnum> : AbstractValidator<T>, IValidator<T>
        where TValidationErrorCodeEnum : struct
    {
        private ValidationResult ToValidationResult(FluentValidation.Results.ValidationResult fluentValidationResult)
        {
            var errors = fluentValidationResult.Errors.Select(e => new ValidationError(Enum.GetName(typeof(TValidationErrorCodeEnum), e.CustomState), e.ErrorMessage));
            var result = new ValidationResult(fluentValidationResult.IsValid, errors, ModelType);
            return result;
        }

        new public ValidationResult Validate(T entity)
        {
            var validationResult = base.Validate(entity);
            return ToValidationResult(validationResult);
        }

        public Type ModelType
        {
            get { return typeof(T); }
        }

        public ValidationResult Validate(object entity)
        {
            return Validate((T)entity);
        }
    }
}