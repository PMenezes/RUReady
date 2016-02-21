using Models;
using Repositories.Configs.ModelConfigs;
using System.Data.Entity;

namespace Repositories.Configs
{
    public class RuReadyContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dare> Dares { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }


        public RuReadyContext() : base("RuReadyContext")
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new DareConfiguration());
            modelBuilder.Configurations.Add(new ResponseConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
