using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUReadyAPI.Models
{
    public class Dare
    {
        public Guid Key { get; set; }
        public int Dificulty { get; set; }

        #region References
        public User User { get; set; }
        public Category Category { get; set; }
        #endregion
    }
}