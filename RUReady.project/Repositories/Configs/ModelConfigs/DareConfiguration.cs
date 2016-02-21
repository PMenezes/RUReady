using Models;

namespace Repositories.Configs.ModelConfigs
{
    public class DareConfiguration : DomainEntityTypeConfiguration<Dare>
    {
        public DareConfiguration()
        {
            Property(dare => dare.Dificulty).IsRequired();

            #region Navigation Properties

            HasMany(dare => dare.Responses).WithOptional(response => response.Dare);

            #endregion    
        }
    }
}
