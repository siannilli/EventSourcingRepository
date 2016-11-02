using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedDomainsObjects.Enum;

namespace SharedDomainsObjects.ValueObjects
{
    public class DemurrageRate: BaseValueObject<DemurrageRate>
    {

        public double LoadHoursLaytime { get; private set; }
        public double DischargeHoursLaytime { get; private set; }
        public double TotalHoursLaytime { get; private set; }

        public CostAmount Price { get; private set; }

        public DemurrageRateInterval PriceInterval { get; private set; }


    }
}
