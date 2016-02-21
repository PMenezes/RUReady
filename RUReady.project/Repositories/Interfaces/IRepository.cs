using System;
using System.Linq;

namespace Repositories.Interfaces
{
    /// <summary>
    /// Base Interface for the repositories
    /// </summary>
    /// <typeparam name="T">Model Type</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Starts a query.
        /// </summary>
        /// <returns>Queriable of the list of T</returns>
        IQueryable<T> Query(bool eagerLoad = false);

        /// <summary>
        /// Fetches an instance of T based on the info on model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eagerLoad"></param>
        /// <returns>The T with the ID</returns>
        T GetById(Guid id, bool eagerLoad = false);

        /// <summary>
        /// Fetches an instance of T based on the info on model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="eagerLoad"></param>
        /// <returns>The T with the ID</returns>
        T Get(T model, bool eagerLoad = false);

        /// <summary>
        /// Persists the model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The inserted T</returns>
        T Insert(T model);

        /// <summary>
        /// Updates an exisiting model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Updated T</returns>
        T Update(T model);

        /// <summary>
        /// Deletes an existing model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true if the model was deleted successfully</returns>
        bool Delete(T model);
    }
}
