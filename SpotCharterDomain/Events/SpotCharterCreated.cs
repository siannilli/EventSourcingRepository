using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase;
using EventSourcingStoreBase.Events;
using SharedDomainsObjects.Entities;
using SharedDomainsObjects.ValueObjects;

namespace SpotCharterDomain.Events
{
    public class SpotCharterCreated : BaseEvent
    {
        public SpotCharterCreated(Guid eventId,
            Guid spotId,
            ulong version,
            DateTime charterpartyDate,
            Counterparty counterparty,
            Vessel vessel, 
            CargoQuantity minimumQuantity) 
            : base(eventId, spotId, version)
        {

        }

        public DateTime CharterpartyDate { get; private set; }
        public Counterparty Counterparty { get; private set; }
        public Vessel Vessel { get; private set; }
        public CargoQuantity MinimumQuantity { get; private set; }
    }
}
