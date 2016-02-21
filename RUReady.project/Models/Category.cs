using System;
using System.Collections.Generic;

namespace Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        #region References
        public virtual ICollection<Dare> Dares { get; set; }
        #endregion
    }
}
