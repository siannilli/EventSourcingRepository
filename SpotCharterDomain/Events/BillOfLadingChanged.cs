using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDomainObjects.Events;
using SharedShippingDomainsObjects.ValueObjects;

namespace SpotCharterDomain.Events
{
    public class BillOfLadingChanged: Event
    {
        public BillOfLadingChanged(Guid eventId, ulong version, SpotCharterId sourceId, 
            DateTime date,
            CargoQuantity quantity,
            string documentReference)
            :base(eventId, version)
        {
            this.SourceId = sourceId;
            this.Date = date;
            this.Quantity = quantity;
        }

        public DateTime Date { get; private set; }
        public string DocumentReference { get; private set; }
        public CargoQuantity Quantity { get; private set; }
        public SpotCharterId SourceId { get; private set; }

    }
}
