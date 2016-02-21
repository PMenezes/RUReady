using System;
using System.Collections.Generic;

namespace RUReadyAPI.Models
{
    public class Category
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #region References
        public ICollection<Dare> Dares { get; set; }
    }
}               