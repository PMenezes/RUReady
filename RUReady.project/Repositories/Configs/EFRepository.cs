using Models;
using Repositories.Exceptions;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Configs
{
    /// <summary>
    /// A Repository base that implements common functions.
    /// <para>This repository base is intended to be used with EF5.</para>
    /// </summary>
    /// <typeparam name="TModel">The type of Domain Model mainly used by the repository.</typeparam>
    public abstract class EFRepository<TModel> : IRepository<TModel> where TModel : Entity, new()
    {
        /// <summary>
        /// Gets the Current EntitiesContext.
        /// </summary>
        protected IContext Context { get; private set; }

        /// <summary>
        /// The {TModel} DbSet.
        /// </summary>
        private DbSet<TModel> DbSet { get { return Context.Set<TModel>(); } }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entitiesContext"></param>
        /// <param name="exceptionTransformation"></param>
        protected EFRepository(IContext entitiesContext)
        {
            Context = entitiesContext;
        }

        /// <summary>
        /// Starts a Query.
        /// <example>
        ///     // use linq to filter or add other clauses to the query.
        ///     repo.Query().Where(e => e.field == "");
        /// </example>
        /// </summary>
        /// <returns>Returns a IEnumerable representing the query.</returns>
        public IQueryable<TModel> Query(bool eagerLoad = false)
        {
            return eagerLoad ? DbSet : GetForeignKeyValues().Aggregate((IQueryable<TModel>)DbSet, (current, includeExpression) => current.Include(includeExpression));
        }

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="id"></param>
        /// <param name="eagerLoad"></param>
        /// <returns></returns>
        public TModel GetById(Guid id, bool eagerLoad = false)
        {
            return !eagerLoad && !GetForeignKeyValues().Any()
                ? DbSet.Find(GetEntityKeyValues(new TModel { Key = id }).ToArray())
                : Query().FirstOrDefault(m => m.Key == id);
        }

        /// <summary>
        /// Fetch an instance of TModel based on the given model.
        /// </summary>
        /// <param name="model">The model of an entity</param>
        /// <param name="eagerLoad"></param>
        /// <returns>An instance of TModel with all fields filled with persisted data.</returns>
        public TModel Get(TModel model, bool eagerLoad = false)
        {
            return model == null
                ? null
                : !eagerLoad && !GetForeignKeyValues().Any()
                    ? DbSet.Find(GetEntityKeyValues(model).ToArray())
                    : Query().FirstOrDefault(m => m.Key == model.Key);
        }

        /// <summary>
        /// Persists the changes made in the model.
        /// </summary>
        /// <param name="model">The type of domain model.</param>
        /// <returns>The updated model.</returns>
        public virtual TModel Update(TModel model)
        {
            model.EnsureNotNull(new MissingModelException<TModel>("To update a [{0}] be sure to have a instance of that type."));

            if (Get(model) == null)
            {
                throw new EntityNotFoundException("The entity [{0}] with identity: [{1}] was not found.", typeof(TModel).Name, String.Join(", ", GetEntityKeyValues(model)));
            }

            var entry = Context.Entry(model);
            try
            {
                model = DbSet.Attach(model);

                entry.State = EntityState.Modified;

                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Exception raise = ex;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("An object with the same key already exists in the ObjectStateManager"))
                {
                    throw new UnableToUpdateException(ex, "The entity [{0}] with identity [{1}] must be fetched before updated.", typeof(TModel).Name, String.Join(", ", GetEntityKeyValues(model)));
                }

                throw;
            }

            return model;
        }

        /// <summary>
        /// Persists the model.
        /// </summary>
        /// <param name="model">The type of domain model.</param>
        /// <returns>The inserted model.</returns>
        public virtual TModel Insert(TModel model)
        {
            model.EnsureNotNull(new MissingModelException<TModel>("To insert a [{0}] be sure to have a instance of that type."));

            try
            {
                model = DbSet.Add(model);

                var result = Context.SaveChanges();

                return result > 0 ? model : null;
            }
            catch (DbEntityValidationException ex)
            {
                Exception raise = ex;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        /// <summary>
        /// Deletes the model from being persisted.
        /// </summary>
        /// <param name="model">The model of an entity</param>
        /// <returns><c>true</c> if model was deleted. Otherwise <c>false</c>.</returns>
        public virtual bool Delete(TModel model)
        {
            model.EnsureNotNull(new MissingModelException<TModel>("To delete a [{0}] be sure to have a instance of that type."));

            model = Get(model);

            if (model == null)
            {
                return false;
            }

            var result = DbSet.Remove(model) != null;

            Context.SaveChanges();
           
            return result;
        }

        /// <summary>
        /// Given a model returns its key values.
        /// </summary>
        /// <param name="model">The model that contains the key values.</param>
        /// <returns>a sequence of key values.</returns>
        protected abstract IEnumerable<object> GetEntityKeyValues(TModel model);

        /// <summary>
        /// Set Properties to include in the Getter Methods
        /// </summary>
        /// <returns>List of expressions of the Model properties</returns>
        protected abstract IEnumerable<Expression<Func<TModel, object>>> GetForeignKeyValues();
    }
}
