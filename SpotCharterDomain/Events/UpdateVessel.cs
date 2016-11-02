using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase.Events;
using SharedDomainsObjects.Entities;

namespace SpotCharterDomain.Events
{
    public class UpdateVessel : BaseEvent
    {
        public UpdateVessel(Guid eventId, ulong version, Vessel vessel) : base(eventId, version)
        {
            this.Vessel = vessel;
        }

        public Vessel Vessel { get; private set; }
    }
}
