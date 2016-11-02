using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingStoreBase
{
    public interface ICommand
    {
        Guid Id { get; }
        ulong Version { get; set; }

    }
}
