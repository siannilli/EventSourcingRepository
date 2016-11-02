using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase;

namespace EventSourcingStoreBase.Commands
{
    public abstract class BaseCommand : ICommand
    {
        Guid _id;
        public Guid Id{get; private set;}
        public ulong Version { get; private set; }

        public Guid AggregateId { get; private set; }

        Guid ICommand.Id
        {
            get
            {
                return this.Id;
            }
        }

        ulong ICommand.Version
        {
            get
            {
                return this.Version ;
            }

            set
            {
                this.Version = value;
            }
        }

        public BaseCommand(Guid aggregateId, ulong version)
        {
            this.AggregateId = aggregateId;
            this.Version = version;
        }

        public BaseCommand(IAggregate aggregate)
            : this(aggregate.Id, (aggregate.EventsHistory?.Max(e => e.Version) ?? 0) + 1)
        {

        }

    }
}
