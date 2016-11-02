using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingStoreBase
{
    public interface IEvent
    {
        Guid Id { get; }
        string EventName { get; }
        ulong Version { get; }
    }
}
