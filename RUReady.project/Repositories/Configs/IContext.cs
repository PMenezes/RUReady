using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Repositories.Configs
{
    /// <summary>
    /// Represents a Database context.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Gets the current <see cref="DbSet{TEntity}"/>.
        /// </summary>
        /// <typeparam name="TModel">The type of model used by the <see cref="DbSet{TEntity}"/></typeparam>
        /// <returns>Returns a <see cref="DbSet{TEntity}"/></returns>
        DbSet<TModel> Set<TModel>() where TModel : class;

        /// <summary>
        /// Reset all changes made in this context.
        /// </summary>
        void ReloadContext();

        /// <summary>
        /// Gets the <see cref="ObjectContext"/> instance.
        /// </summary>
        /// <returns>Returns the <see cref="ObjectContext"/>.</returns>
        ObjectContext GetObjectContext();

        /// <summary>
        /// Begins a new transaction.
        /// </summary>
        /// <returns>A <see cref="IDbTransaction"/> implementation.</returns>
        IDbTransaction BeginTransaction();

        /// <summary>
        /// Gets the underlying <see cref="EntityConnection"/>
        /// </summary>
        /// <returns>Returns the <see cref="EntityConnection"/></returns>
        EntityConnection GetConnection();

        /// <summary>
        /// Gets the entry reference for the given model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <typeparam name="TModel">The type of model.</typeparam>
        /// <returns>Returns a <see cref="DbEntityEntry{TEntity}"/> instance.</returns>
        DbEntityEntry<TModel> Entry<TModel>(TModel model) where TModel : class;

        /// <summary>
        /// Saves all changes made in this context.
        /// </summary>
        /// <returns>The number of entities changed.</returns>
        int SaveChanges();

        /// <summary>
        /// Executes a query
        /// </summary>
        /// <param name="query">string representing a query</param>
        /// <typeparam name="TT"></typeparam>
        /// <returns></returns>
        TT SqlQuery<TT>(string query);

        /// <summary>
        /// Executes a query
        /// </summary>
        /// <param name="query">string representing a query</param>
        /// <typeparam name="TT"></typeparam>
        /// <returns></returns>
        IEnumerable<TT> SqlListQuery<TT>(string query);
    }
}
