using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedShippingDomainsObjects.ValueObjects
{
    public class PortId: BaseDomainObjects.ValueObjects.ValueObject<Guid>
    {
        public PortId(Guid value)
        {
            this.Value = value;
        }
    }
}
