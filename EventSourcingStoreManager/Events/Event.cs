using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDomainObjects.Events
{
    public class Event : IEvent
    {
        public Event(Guid eventId, ulong version)
        {
            this.EventId = eventId;
            this.Version = version;
        }

        public Event(Guid eventId, ulong version, string source)
            : this(eventId, version)
        {
            this.Source = source;
        }

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

        string IEvent.Source
        {
            get
            {
                return this.Source;
            }
        }

        public string Source { get; private set; }
    }
}
