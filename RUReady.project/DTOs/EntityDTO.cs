using System;

namespace DTOs
{
    public abstract class EntityDTO
    {
        public Guid Key { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
