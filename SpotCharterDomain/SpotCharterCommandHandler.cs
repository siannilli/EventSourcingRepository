using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase;
using EventSourcingStoreBase.Commands;
using SpotCharterDomain.Commands;

namespace SpotCharterDomain
{
    public class SpotCharterCommandHandler :
        ICommandHandler<Commands.CreateSpotCharter>
    {
        void ICommandHandler<CreateSpotCharter>.Handle(CreateSpotCharter command)
        {
            throw new NotImplementedException();
        }

    }
}
