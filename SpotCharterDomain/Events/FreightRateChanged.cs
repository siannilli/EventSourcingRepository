using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase.Events;

namespace SpotCharterDomain.Events
{
    public class FreightRateChanged: BaseEvent
    {
        public FreightRateChanged(Guid eventId, Guid spotId, ulong version, ValueObjects.FreightRate freightRate)
            : base(eventId, spotId, version)
        {

        }

        public ValueObjects.FreightRate FreightRate { get; private set; }

    }
}
