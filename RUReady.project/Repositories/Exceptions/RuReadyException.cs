using System;

namespace Repositories.Exceptions
{
    /// <summary>
    /// Exception base for all application exceptions
    /// </summary>
    public abstract class RuReadyException : Exception
    {
        /// <summary>
        /// Constructor with simple message.
        /// </summary>
        /// <param name="message">The message for the exception.</param>
        protected RuReadyException(string message)
            : this(null, message)
        {
        }

        /// <summary>
        /// Constructor with a formatted message.
        /// </summary>
        /// <remarks>uses <c>String.Format</c></remarks>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments to be used by String.Format</param>
        protected RuReadyException(string format, params Object[] args)
            : this(null, format, args)
        {
        }

        /// <summary>
        /// Constructor with a formatted message.
        /// </summary>
        /// <remarks>uses <c>String.Format</c></remarks>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments to be used by String.Format</param>
        protected RuReadyException(Exception innerException, string format, params Object[] args)
            : this(innerException, string.Format(format, args))
        {
        }

        /// <summary>
        /// Constructor with a simple message.
        /// </summary>
        /// <remarks>uses <c>String.Format</c></remarks>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="message">The message for the exception.</param>
        protected RuReadyException(Exception innerException, string message)
            : base(message, innerException)
        {
        }
    }
}