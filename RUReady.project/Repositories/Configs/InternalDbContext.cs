using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Repositories.Configs
{
    /// <summary>
    /// Wrapper over a DbContext. This type is a helper to enable context disposal.
    /// </summary>
    /// <typeparam name="TDbContext">The type of wrapped DbContext</typeparam>
    internal class InternalDbContext<TDbContext> : IContext where TDbContext : DbContext, new()
    {
        private TDbContext _context;

        public InternalDbContext()
        {
            ReloadContext();
        }

        public DbSet<TModel> Set<TModel>() where TModel : class
        {
            return _context.Set<TModel>();
        }

        public void ReloadContext()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            _context = new TDbContext();
        }

        public ObjectContext GetObjectContext()
        {
            return _context.GetObjectContext();
        }

        public IDbTransaction BeginTransaction()
        {
            return _context.BeginTransaction();
        }

        public EntityConnection GetConnection()
        {
            return _context.GetConnection();
        }

        public DbEntityEntry<TModel> Entry<TModel>(TModel model) where TModel : class
        {
            return _context.Entry(model);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public TT SqlQuery<TT>(string query)
        {
            return _context.Database.SqlQuery<TT>(query).FirstOrDefault();
        }

        public IEnumerable<TT> SqlListQuery<TT>(string query)
        {
            return _context.Database.SqlQuery<TT>(query).ToList();
        }
    }

    internal static class EFExtensions
    {
        public static ObjectContext GetObjectContext(this DbContext context)
        {
            return ((IObjectContextAdapter)context).ObjectContext;
        }

        public static EntityConnection GetConnection(this DbContext context)
        {
            return context.GetObjectContext().Connection as EntityConnection;
        }

        public static IDbTransaction BeginTransaction(this DbContext context)
        {
            return context.GetConnection().BeginTransaction();
        }
    }
}
