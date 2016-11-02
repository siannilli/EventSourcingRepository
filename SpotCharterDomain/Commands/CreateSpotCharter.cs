using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventSourcingStoreBase;
using EventSourcingStoreBase.Commands;

namespace SpotCharterDomain.Commands
{
    public class CreateSpotCharter : BaseCommand
    {
        public CreateSpotCharter(SpotCharter spot)
            : base(spot)
        {

        }



    }
}
