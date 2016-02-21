using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Entity : IEntity
    {
        private Guid _key { get; set; }

        public Guid Key
        {
            get { return _key; }
            set
            {
                _key = value == Guid.Empty ? Guid.NewGuid() : value;
            }
        }

        private DateTime _creationDateTime;

        public DateTime CreationDateTime
        {
            get { return _creationDateTime == default(DateTime) ? DateTime.UtcNow : _creationDateTime; ; }
            set
            {
                _creationDateTime = value == default(DateTime) ? DateTime.UtcNow : value;
            }
        }
    }
}
