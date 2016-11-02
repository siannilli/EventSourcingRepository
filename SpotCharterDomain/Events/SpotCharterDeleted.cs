using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCharterDomain.Events
{
    class SpotCharterDeleted : EventSourcingStoreBase.Events.BaseEvent
    {
        public SpotCharterDeleted(Guid eventId, ulong version) : base(eventId, version)
        {
        }
    }
}
