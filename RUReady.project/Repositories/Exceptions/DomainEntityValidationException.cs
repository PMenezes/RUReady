using Repositories.Validators;
using System;
using System.Collections.Generic;

namespace Repositories.Exceptions
{
    /// <summary>
    /// Exception thrown when a validation constraint is not verified.
    /// </summary>
    public class DomainEntityValidationException : ModelValidationException, IValidationBag
    {
        /// <summary>
        /// Gets the validation Errors.
        /// </summary>
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Construtor for <see cref="DomainEntityValidationException"/>
        /// </summary>
        /// <param name="modelType">The type of model.</param>
        /// <param name="validationErrors">The validation errors.</param>
        public DomainEntityValidationException(Type modelType, IEnumerable<ValidationError> validationErrors = null)
            : base("The specified {0} is not valid.", modelType.Name)
        {
            ValidationErrors = validationErrors;
        }
    }
}