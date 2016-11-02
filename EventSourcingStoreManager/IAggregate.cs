using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingStoreBase
{
    public interface IAggregate
    {
        System.Guid Id { get; }
        IEnumerable<IEvent> Events { get; }
        ulong Version { get; }
    }
}
