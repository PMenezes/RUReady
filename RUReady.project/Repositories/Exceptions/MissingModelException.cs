namespace Repositories.Exceptions
{
    public class MissingModelException<TModel> : ValidationException
    {
        public MissingModelException(string message)
            : base(message, typeof(TModel).Name)
        {
        }
    }
}