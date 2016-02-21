using Models;
using Repositories.Configs;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Implementations
{
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IContext entitiesContext)
            : base(entitiesContext)
        {
        }

        protected override IEnumerable<object> GetEntityKeyValues(Category model)
        {
            yield return model.Key;
        }

        protected override IEnumerable<Expression<Func<Category, object>>> GetForeignKeyValues()
        {
            throw new NotImplementedException();
        }
    }
}
