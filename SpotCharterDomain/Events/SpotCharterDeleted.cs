using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedShippingDomainsObjects.ValueObjects;

namespace SpotCharterDomain.Events
{
    class SpotCharterDeleted : BaseDomainObjects.Events.Event
    {
        public SpotCharterDeleted(Guid eventId, ulong version, SpotCharterId spotId) : base(eventId, version)
        {
            this.SourceId = spotId;
        }

        public SpotCharterId SourceId { get; private set; }
    }
}
