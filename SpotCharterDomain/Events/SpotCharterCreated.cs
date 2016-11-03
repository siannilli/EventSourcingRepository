using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDomainObjects;
using BaseDomainObjects.Events;
using SharedShippingDomainsObjects.Entities;
using SharedShippingDomainsObjects.ValueObjects;

namespace SpotCharterDomain.Events
{
    public class SpotCharterCreated : Event
    {
        public SpotCharterCreated(Guid eventId,
            ulong version,
            SpotCharterId spotId,            
            DateTime charterpartyDate,
            Counterparty counterparty,
            Vessel vessel, 
            CargoQuantity minimumQuantity) 
            : base(eventId, version)
        {
            this.SourceId = spotId;
            this.CharterpartyDate = charterpartyDate;
            this.Counterparty = counterparty;
            this.Vessel = vessel;
            this.MinimumQuantity = minimumQuantity;
        }

        public DateTime CharterpartyDate { get; private set; }
        public Counterparty Counterparty { get; private set; }
        public Vessel Vessel { get; private set; }
        public CargoQuantity MinimumQuantity { get; private set; }        
        public SpotCharterId SourceId { get; private set; }
    }
}
