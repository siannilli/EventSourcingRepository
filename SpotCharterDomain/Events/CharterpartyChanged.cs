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
    public class CharterpartyChanged: Event
    {
        public CharterpartyChanged(Guid eventId, ulong version, SpotCharterId spotId, Counterparty charterparty)
            : base(eventId, version)
        {
            this.SouceId = spotId;
            this.Charterparty = charterparty;
        }

        public Counterparty Charterparty { get; private set; }
        public SpotCharterId SouceId { get; private set; }
    }
}
