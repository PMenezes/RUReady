using Models;
using Repositories.Configs;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Implementations
{
    public class DareRepository : EFRepository<Dare>, IDareRepository
    {
        public DareRepository(IContext entitiesContext)
            : base(entitiesContext)
        {
        }

        protected override IEnumerable<object> GetEntityKeyValues(Dare model)
        {
            yield return model.Key;
        }

        protected override IEnumerable<Expression<Func<Dare, object>>> GetForeignKeyValues()
        {
            return new Expression<Func<Dare, object>>[]
            {
                dare => dare.Responses,
                dare => dare.From,
                dare => dare.To
            };
        }
    }
}
