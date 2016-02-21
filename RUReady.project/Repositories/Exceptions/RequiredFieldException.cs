using System;

namespace Repositories.Exceptions
{
    /// <summary>
    ///
    /// </summary>
    public class RequiredFieldException : RuReadyException
    {
        /// <summary>
        /// Constructor with a formatted message.
        /// </summary>
        /// <remarks>uses <c>String.Format</c></remarks>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments to be used by String.Format</param>
        public RequiredFieldException(string format, params object[] args)
            : base(format, args)
        {
        }

        /// <summary>
        /// Constructor with a formatted message.
        /// </summary>
        /// <remarks>uses <c>String.Format</c></remarks>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="format">The format</param>
        /// <param name="args">The arguments to be used by String.Format</param>
        public RequiredFieldException(Exception innerException, string format, params object[] args)
            : base(innerException, format, args)
        {
        }
    }
}