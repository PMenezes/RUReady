using System.Collections.Generic;

namespace RUReadyAPI.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region References
        public virtual ICollection<Dare> Dares { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        #endregion
    }
}