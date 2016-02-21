using System;

namespace Repositories.Exceptions.ExeptionTransformation
{
    internal class ForeignKeyViolationExceptionTransformation<TModel> : IExceptionTransformation<TModel>
    {
        public Exception Transform(Exception ex, TModel model, object[] args)
        {
            var sqlException = ex.GetSqlException().EnsureNotNull(ex);

            return sqlException.Errors.Count > 0
                && sqlException.Errors[0].Number == 547 ? new RequiredFieldException(ex, sqlException.Message) : null;
        }

        public Exception Transform(Exception exception, object[] args)
        {
            return null;
        }
    }
}