using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase.Events;
using SharedDomainsObjects.Entities;

namespace SpotCharterDomain.Events
{
    public class VesselChanged : BaseEvent
    {
        public VesselChanged(Guid eventId, Guid spotId, ulong version, Vessel vessel) : base(eventId, spotId, version)
        {
            this.Vessel = vessel;
        }

        public Vessel Vessel { get; private set; }
    }
}
