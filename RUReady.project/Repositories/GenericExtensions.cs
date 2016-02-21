using Repositories.Exceptions;
using System;

namespace Repositories
{
    /// <summary>
    /// Generic types helper.
    /// <para>Used to make validations over generic type instances.</para>
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Ensures that result is not null. If null throw ex.
        /// </summary>
        /// <typeparam name="TResult">The type of result expected not to be null.</typeparam>
        /// <param name="result">The result instance returned if not null.</param>
        /// <param name="ex">The exception throwed if result is null.</param>
        /// <returns>The result instance if not null or ex.</returns>
        public static TResult EnsureNotNull<TResult>(this TResult result, Exception ex)
        {
            (result == null).EnsureFalse(ex);

            return result;
        }

        /// <summary>
        /// Ensures that the string is not null nor empty. If NullOrEmpty throws the given exception.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <param name="ex">The exception to be throwed.</param>
        /// <returns>The string received.</returns>
        public static String EnsureNotNullOrEmpty(this String value, Exception ex)
        {
            String.IsNullOrEmpty(value).EnsureFalse(ex);

            return value;
        }

        /// <summary>
        /// Ensures that result is null. If not null throw ex.
        /// </summary>
        /// <typeparam name="TResult">The type of result expected to be null.</typeparam>
        /// <param name="result">The result instance returned if null.</param>
        /// <param name="ex">The exception throwed if result is not null.</param>
        /// <returns>The result instance if null or ex.</returns>
        public static TResult EnsureNull<TResult>(this TResult result, Exception ex)
        {
            (result == null).EnsureTrue(ex);

            return result;
        }

        /// <summary>
        /// Ensures that an object is not null. If null throw <see cref="ModelValidationException"/>.
        /// </summary>
        /// <param name="obj">An intance of something</param>
        /// <param name="exceptionMessage">Message to be formatted with String.Format.</param>
        /// <param name="args">Arguments to be replaced in the message placeholders.</param>
        /// <exception cref="ModelValidationException"></exception>
        public static void EnsureNotNull(this Object obj, String exceptionMessage, params Object[] args)
        {
            obj.EnsureNotNull(new ModelValidationException(exceptionMessage, args));
        }

        /// <summary>
        /// Ensures that the given value is <c>true</c> or ex is throwed!
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <param name="ex">The exception throwed if value is <c>false</c>.</param>
        public static void EnsureTrue(this Boolean value, Exception ex)
        {
            if (!value) throw ex;
        }

        /// <summary>
        /// Ensures that the given value is <c>false</c> or ex is throwed!
        /// </summary>
        /// <param name="value">The value to be evaluated.</param>
        /// <param name="ex">The exception throwed if value is <c>true</c>.</param>
        public static void EnsureFalse(this Boolean value, Exception ex)
        {
            if (value) throw ex;
        }
    }
}
