using System;
using System.Data.SqlClient;

namespace Repositories.Exceptions.ExeptionTransformation
{
    /// <summary>
    /// Handler to transform/wrap exceptions that are known to system exception types.
    /// </summary>
    public interface IExceptionTransformation
    {
        /// <summary>
        /// Transforms an Oracle Exception to an Application Exception
        /// </summary>
        /// <param name="exception">The exception to wrap or throw.</param>
        /// <param name="args">Any arguments to be used internaly by String.Format function.</param>
        /// <returns></returns>
        Exception Transform(Exception exception, params Object[] args);
    }

    /// <summary>
    /// Handler to transform/wrap exceptions that are known to system exception types.
    /// </summary>
    /// <typeparam name="TModel">The type of model used in the handling context.</typeparam>
    public interface IExceptionTransformation<in TModel> : IExceptionTransformation
    {
        /// <summary>
        /// Transforms an Oracle Exception to an Application Exception
        /// </summary>
        /// <param name="exception">The exception to wrap or throw.</param>
        /// <param name="model">The entity model.</param>
        /// <param name="args">Any arguments to be used internaly by String.Format function.</param>
        /// <returns></returns>
        Exception Transform(Exception exception, TModel model, params Object[] args);
    }

    internal static class ExceptionsExtensions
    {
        public static SqlException GetSqlException(this Exception exception)
        {
            var updateException = exception.InnerException;

            if (updateException == null)
            {
                return null;
            }

            return (updateException.InnerException as SqlException);
        }
    }
}