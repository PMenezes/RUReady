using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configs.ModelConfigs
{
    /// <summary>
    /// Base configuration class, defines the id property, common on all enities.
    /// </summary>
    public class DomainEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntity
    {
        protected DomainEntityTypeConfiguration()
        {
            HasKey(x => x.Key);
        }
    }
}
