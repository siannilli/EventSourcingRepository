using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedDomainsObjects.ValueObjects;

namespace SpotCharterDomain.Events
{
    public class DemurrageRateChanged : EventSourcingStoreBase.Events.BaseEvent
    {
        public DemurrageRateChanged(Guid eventId, Guid sourceId, ulong version, DemurrageRate rate) : base(eventId, sourceId, version)
        {

        }

        public DemurrageRate Rate { get; private set; }
    }
}
