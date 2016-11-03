using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedShippingDomainsObjects.ValueObjects;
using SharedShippingDomainsObjects.Enums;
namespace SpotCharterDomain.Events
{
    public class DemurrageRateChanged : BaseDomainObjects.Events.Event
    {
        public DemurrageRateChanged(Guid eventId, SpotCharterId sourceId, ulong version,
            DemurrageRate rate) 
            : base(eventId, version)
        {
            this.Rate = rate;
        }


        public DemurrageRate Rate { get; private set; }
    }
}
