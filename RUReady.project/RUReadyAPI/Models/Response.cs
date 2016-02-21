using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RUReadyAPI.Models
{
    public class Response
    {
        public string Type { get; set; }
        public string Answer { get; set; }
        public string Content { get; set; }

        #region References
        public User User { get; set; }
        public Dare Dare { get; set; }
        #endregion
    }
}