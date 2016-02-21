using Models.Enums;
using System;

namespace Models
{
    public class Response : Entity
    {
        public ResponseType Type { get; set; }
        public string Answer { get; set; }
        public string Content { get; set; }

        #region References
        public virtual User From { get; set; }
        public virtual User To { get; set; }
        public virtual Dare Dare { get; set; }
        #endregion
    }
}
