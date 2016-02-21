namespace Repositories.Validators
{
    /// <summary>
    /// Service for Validation of Domain Entities
    /// </summary>
    public interface IEntityValidation
    {
        /// <summary>
        /// Validates the given entiry.
        /// </summary>
        /// <param name="entity">The entity to be validated.</param>
        /// <typeparam name="TInput">The type of entity.</typeparam>
        /// <returns>A <see cref="ValidationResult"/> instance.</returns>
        ValidationResult Validate<TInput>(TInput entity);
    }
}