using System;

namespace Repositories.Validators
{
    /// <summary>
    ///
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        ///
        /// </summary>
        Type ModelType { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ValidationResult Validate(object input);
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IValidator<in TInput> : IValidator
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ValidationResult Validate(TInput entity);
    }
}