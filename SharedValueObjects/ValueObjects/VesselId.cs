using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedShippingDomainsObjects.ValueObjects
{
    public class VesselId: BaseDomainObjects.ValueObjects.ValueObject<Guid>
    {
        public VesselId(Guid value)
        {
            this.Value = value;
        }
    }
}
