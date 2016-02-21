using DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ResponseDTO : EntityDTO
    {
        public ResponseType Type { get; set; }
        public string Answer { get; set; }
        public string Content { get; set; }

        #region References
        public virtual UserDTO User { get; set; }
        public virtual DareDTO Dare { get; set; }
        #endregion
    }
}
