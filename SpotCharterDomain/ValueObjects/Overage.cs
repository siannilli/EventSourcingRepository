using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedDomainsObjects.ValueObjects;

namespace SpotCharterDomain.ValueObjects
{
    public class Overage: BaseValueObject<Overage>
    {
        public Enums.OverageType Type { get; private set; }
        public decimal Value { get; private set; }

        public Overage(Enums.OverageType type, decimal value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}
