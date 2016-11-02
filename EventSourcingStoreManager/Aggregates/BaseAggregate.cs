using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingStoreBase.Aggregates
{
    public class BaseAggregate : IAggregate
    {
        private readonly Dictionary<Type, Action<IEvent>> handlers = new Dictionary<Type, Action<IEvent>>();
        ulong version = 0;

        public Guid Id { get; private set; }
        IList<IEvent> pendingEvents = new List<IEvent>();

        public BaseAggregate(Guid id)
        {
            this.Id = id;
        }

        public BaseAggregate(Guid id, IEnumerable<IEvent> events)
            : this(id)
        {
            this.eventsHistory = events.ToArray();
        }
               
        public void Handles<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent
        {
            this.handlers[typeof(TEvent)] = @event => eventHandler((TEvent)@event);
        } 

        Guid IAggregate.Id
        {
            get
            {
                return this.Id;
            }
        }

        protected void ReplayEvents(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                var handler = this.handlers[@event.GetType()];
                handler.Invoke(@event);
            }

            this.version = events.Max(e => e.Version);
        }

        protected void PlayEvent(IEvent @event)
        {
            var handler = this.handlers[@event.GetType()];
            handler.Invoke(@event);
            this.pendingEvents.Add(@event);
        }

        IEnumerable<IEvent> IAggregate.Events
        {
            get
            {
                return this.pendingEvents;
            }
        }

        ulong IAggregate.Version
        {
            get
            {
                return this.version + (ulong)this.pendingEvents.Count();
            }
        }

        public override bool Equals(object obj)
        {
            return (obj != null 
                && obj is BaseAggregate
                && this.Id.Equals(((BaseAggregate)obj).Id))
                && this.version.Equals(((IAggregate)obj).Version)
                || base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

    }
}
