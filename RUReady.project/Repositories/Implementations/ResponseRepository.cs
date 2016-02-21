using Models;
using Repositories.Configs;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Implementations
{
    public class ResponseRepository : EFRepository<Response>, IResponseRepository
    {
        public ResponseRepository(IContext entitiesContext)
            : base(entitiesContext)
        {
        }

        protected override IEnumerable<object> GetEntityKeyValues(Response model)
        {
            yield return model.Key;
        }

        protected override IEnumerable<Expression<Func<Response, object>>> GetForeignKeyValues()
        {
            return new Expression<Func<Response, object>>[]
            {
                dare => dare.From,
                dare => dare.To,
                response => response.Dare
            };
        }
    }
}
