using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDomainObjects;

namespace BaseDomainObjects.Commands
{
    public abstract class Command<T, TIdentity> : ICommand where T : IEventSourcedAggregate<TIdentity>
    {
        Guid _id;
        public Guid Id{get; private set;}
        public int Version { get; private set; }

        public TIdentity AggregateId { get; private set; }

        Guid ICommand.Id
        {
            get
            {
                return this.Id;
            }
        }

        int ICommand.Version
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

        public Command(TIdentity aggregateId, int version)
        {
            this.AggregateId = aggregateId;
            this.Version = version;
        }

        public Command(T aggregate)
            : this(aggregate.Id, (aggregate.Version + 1))
        {

        }

    }
}
