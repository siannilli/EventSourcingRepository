using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomainsObjects.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        public BaseEntity(Guid id)
        {
            this.Id = id;
        }

        public override bool Equals(object obj)
        {
            return (obj != null
                && obj is BaseEntity
                && this.Id.Equals(((BaseEntity)obj).Id)) || base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
