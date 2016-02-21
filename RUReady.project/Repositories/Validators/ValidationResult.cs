using System;
using System.Collections.Generic;

namespace Repositories.Validators
{
    /// <summary>
    /// Represents a result of a validation
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        ///
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<ValidationError> ValidationErrors { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public Type ModelType { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isValid"></param>
        /// <param name="validationErrors"></param>
        /// <param name="modelType"></param>
        public ValidationResult(bool isValid, IEnumerable<ValidationError> validationErrors = null, Type modelType = null)
        {
            this.IsValid = isValid;
            this.ValidationErrors = validationErrors;
            ModelType = modelType;
        }
    }
}