using Models.Enums;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Dare : Entity
    {
        public Dificulty Dificulty { get; set; }

        #region References
        public virtual User From { get; set; }
        public virtual ICollection<User> To { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        #endregion
    }
}
