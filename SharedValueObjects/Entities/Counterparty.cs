using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomainsObjects.Entities
{
    public class Counterparty: BaseEntity
    {
        public string Name { get; private set; }

        public Counterparty(Guid id, string name)
            : base(id)
        {
            this.Name = name;
        }
    }
}
