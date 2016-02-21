using Models;

namespace Repositories.Configs.ModelConfigs
{
    public class CategoryConfiguration : DomainEntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            Property(category => category.Name).IsRequired();
            Property(category => category.Description).IsOptional();

            #region Navigation Properties

            HasMany(category => category.Dares).WithRequired(dare => dare.Category);

            #endregion   
        }
    }
}
