using Ninject;
using Repositories.Configs.IOC;
using Repositories.Exceptions;
using System;
using System.Collections.Generic;

namespace Repositories.Validators
{
    /// <summary>
    /// The Validation Bag, constains validation erros.
    /// </summary>
    public interface IValidationBag
    {
        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        IEnumerable<ValidationError> ValidationErrors { get; set; }
    }

    internal static class ValidationExtension
    {
        private static readonly StandardKernel _validationKernel = new StandardKernel(new ValidationModule());

        static ValidationExtension()
        {
            ValidationService = _validationKernel.Get<IEntityValidation>();
        }

        private static readonly IEntityValidation ValidationService;

        public static ValidationResult Validate<T>(this T model)
        {
            return ValidationService.Validate<T>(model);
        }

        public static void EnsureIsValid<T>(this ValidationResult result, T exception) where T : Exception, IValidationBag
        {
            if (!result.IsValid)
            {
                exception.ValidationErrors = result.ValidationErrors;
                throw exception;
            }
        }

        public static void EnsureIsValid(this ValidationResult result)
        {
            if (!result.IsValid)
            {
                throw new DomainEntityValidationException(result.ModelType)
                {
                    ValidationErrors = result.ValidationErrors
                };
            }
        }
    }
}