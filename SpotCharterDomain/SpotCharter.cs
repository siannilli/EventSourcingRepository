using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase;
using EventSourcingStoreBase.Aggregates;
using SharedDomainsObjects.ValueObjects;
using SharedDomainsObjects.Entities;

using SpotCharterDomain.Events;

namespace SpotCharterDomain
{
    public class SpotCharter : BaseAggregate
    {

        public SpotCharter(Guid id)
            : base(id)
        {
            this.Handles<SpotCharterCreated>(OnSpotCharterCreated);

        }

        public SpotCharter(Guid id, DateTime charterpartyDate, Counterparty counterparty, Vessel vessel)
            : this(id)
        {
            this.CharterpartyDate = charterpartyDate;
            this.Counterparty = counterparty;
            this.Vessel = vessel;
        }

        public SpotCharter(Guid id, IEnumerable<IEvent> events )
            :this(id)
        {
            this.ReplayEvents(events);
        }

        public string Code { get; private set;}
        public DateTime? CharterpartyDate { get; private set; }

        public DateRange Laycan { get; private set; }

        public Vessel Vessel { get; private set; }

        public Counterparty Counterparty { get; private set; }
        
        public BillOfLading BillOfLading { get; private set; }

        public Counterparty ShipOwner { get; private set; }



    }
}
