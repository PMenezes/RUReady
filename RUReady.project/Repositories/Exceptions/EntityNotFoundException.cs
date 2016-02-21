namespace Repositories.Exceptions
{
    /// <summary>
    /// Entity not found exception.
    /// </summary>
    public class EntityNotFoundException : RuReadyException
    {
        /// <summary>
        /// Constructor for the the exception.
        /// </summary>
        /// <param name="messageFormat">A message to be parsed by String.Format</param>
        /// <param name="args">Arguments to include in the message.</param>
        public EntityNotFoundException(string messageFormat, params  object[] args)
            : base(messageFormat, args)
        {
        }
    }
}