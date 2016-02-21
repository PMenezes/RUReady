using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDTO : EntityDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #region References
        public virtual ICollection<DareDTO> Dares { get; set; }
        public virtual ICollection<ResponseDTO> Responses { get; set; }
        #endregion
    }
}
