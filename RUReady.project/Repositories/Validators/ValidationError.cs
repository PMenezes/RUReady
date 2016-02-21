namespace Repositories.Validators
{
    /// <summary>
    /// Representation of a validation error.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string ValidationErrorCode { get; private set; }

        /// <summary>
        /// Gets the Error message.
        /// </summary>
        public string ValidationErrorMessage { get; private set; }

        /// <summary>
        /// Constructor for <see cref="ValidationError"/>
        /// </summary>
        /// <param name="validationErrorCode">The error code.</param>
        /// <param name="validationErrorMessage">The error message.</param>
        public ValidationError(string validationErrorCode, string validationErrorMessage)
        {
            ValidationErrorCode = validationErrorCode;
            ValidationErrorMessage = validationErrorMessage;
        }
    }
}