using System;
using System.Collections.Generic;

namespace Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region References
        public virtual ICollection<Dare> DaresSent { get; set; }
        public virtual ICollection<Dare> DaresReceived { get; set; }
        public virtual ICollection<Response> ResponsesSent { get; set; }
        public virtual ICollection<Response> ResponsesReceived { get; set; }
        #endregion
    }
}
