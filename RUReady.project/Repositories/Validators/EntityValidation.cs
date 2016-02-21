using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Validators
{
    /// <summary>
    /// Fluent Validation Service
    /// </summary>
    public class EntityValidation : IEntityValidation
    {
        private IDictionary<Type, IValidator> Validators { get; set; }

        /// <summary>
        /// Constructor for <see cref="EntityValidation"/>
        /// </summary>
        /// <param name="validators">The entity validators.</param>
        public EntityValidation(IEnumerable<IValidator> validators)
        {
            Validators = validators.ToDictionary(v => v.ModelType);
        }

        /// <summary>
        /// Validate the model
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="TInput"></typeparam>
        /// <returns></returns>
        public ValidationResult Validate<TInput>(TInput entity)
        {
            var entityType = entity.GetType();
            return this.Validators[entityType].Validate(entity);
        }
    }
}