using System;

namespace Repositories.Exceptions
{
    public class ModelValidationException : ValidationException
    {
        public ModelValidationException(string format, params object[] args)
            : base(format, args)
        {
        }

        public ModelValidationException(Exception innerException, string format, params object[] args)
            : base(innerException, format, args)
        {
        }
    }
}