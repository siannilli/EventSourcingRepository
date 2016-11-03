using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedShippingDomainsObjects.ValueObjects
{
    public class PortfolioId: BaseDomainObjects.ValueObjects.ValueObject<Guid>
    {
        public PortfolioId(Guid value)
        {
            this.Value = value;
        }
    }
}
