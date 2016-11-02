using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingStoreBase.Events
{
    public class BaseEvent : IEvent
    {
        public BaseEvent(Guid eventId, ulong version)
        {
            this.EventId = eventId;
            this.Version = version;
        }

        public Guid SourceId { get; private set; }
        public Guid EventId { get; private set; }
        public ulong Version { get; private set; }

        string IEvent.EventName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        Guid IEvent.Id
        {
            get
            {
                return this.EventId;
            }

        }

        ulong IEvent.Version
        {
            get
            {
                return this.Version;
            }
        }
    }
}
