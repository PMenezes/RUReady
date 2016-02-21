using Models;
using Repositories.Configs;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Implementations
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(IContext entitiesContext)
            : base(entitiesContext)
        {
        }

        protected override IEnumerable<object> GetEntityKeyValues(User model)
        {
            yield return model.Key;
        }

        protected override IEnumerable<Expression<Func<User, object>>> GetForeignKeyValues()
        {
            return new Expression<Func<User, object>>[]
            {};
    }
    }
}
