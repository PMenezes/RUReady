using System.Collections.Generic;

namespace DTOs
{
    public class CategoryDTO :  EntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        #region References
        public virtual ICollection<DareDTO> Dares { get; set; }
        #endregion
    }
}
