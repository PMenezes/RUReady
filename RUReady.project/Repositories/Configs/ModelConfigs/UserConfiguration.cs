using Models;

namespace Repositories.Configs.ModelConfigs
{
    public class UserConfiguration : DomainEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(user => user.UserName).IsRequired();
            Property(user => user.FirstName).IsRequired();
            Property(user => user.LastName).IsRequired();

            #region Navigation Properties

            HasMany(user => user.DaresSent).WithRequired(dare => dare.From);
            HasMany(user => user.DaresReceived).WithMany(dare => dare.To);
            HasMany(user => user.ResponsesSent).WithRequired(response => response.From);
            HasMany(user => user.ResponsesReceived).WithRequired(response => response.To);

            #endregion  
        }
    }
}
