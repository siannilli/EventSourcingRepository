using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDomainObjects.Events;
using SharedShippingDomainsObjects.Entities;
using SharedShippingDomainsObjects.ValueObjects;

namespace SpotCharterDomain.Events
{
    public class VesselChanged : Event
    {
        public VesselChanged(Guid eventId, ulong version, SpotCharterId spotId, Vessel vessel) : base(eventId, version)
        {
            this.SourceId = spotId;
            this.Vessel = vessel;
        }

        public SpotCharterId SourceId { get; private set; }
        public Vessel Vessel { get; private set; }
    }
}
