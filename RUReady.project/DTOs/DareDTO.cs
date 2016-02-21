using DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DareDTO : EntityDTO
    {
        public Dificulty Dificulty { get; set; }

        #region References
        public virtual UserDTO User { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual ICollection<ResponseDTO> Responses { get; set; }
        #endregion
    }
}
