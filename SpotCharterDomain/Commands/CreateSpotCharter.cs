using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDomainObjects;
using BaseDomainObjects.Commands;

namespace SpotCharterDomain.Commands
{
    public class CreateSpotCharter : Command<SpotCharter, SharedShippingDomainsObjects.ValueObjects.SpotCharterId>
    {
        public CreateSpotCharter(SpotCharter spot)
            : base(spot)
        {

        }



    }
}
