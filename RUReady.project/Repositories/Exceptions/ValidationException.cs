using System;

namespace Repositories.Exceptions
{
    public class ValidationException : RuReadyException
    {
        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string format, params object[] args)
            : base(format, args)
        {
        }

        public ValidationException(Exception innerException, string format, params object[] args)
            : base(innerException, format, args)
        {
        }

        public ValidationException(Exception innerException, string message)
            : base(innerException, message)
        {
        }
    }
}