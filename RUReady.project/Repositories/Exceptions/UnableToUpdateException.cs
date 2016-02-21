using System;

namespace Repositories.Exceptions
{
    /// <summary>
    /// Exception occurs the update operation fails
    /// </summary>
    public class UnableToUpdateException : RuReadyException
    {
        /// <summary>
        /// Constructor for the the exception.
        /// </summary>
        /// <param name="exception">The inner exception captured.</param>
        /// <param name="messageFormat">A message to be parsed by String.Format</param>
        /// <param name="args">Arguments to include in the message.</param>
        public UnableToUpdateException(InvalidOperationException exception, string messageFormat, params Object[] args)
            : base(exception, messageFormat, args)
        {
        }
    }
}