using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseDomainObjects.Commands;
using SharedShippingDomainsObjects.ValueObjects;

namespace SpotCharterServices.Commands
{
    public class ChangeLaycan: Command
    {
        public ChangeLaycan(DateTime from, DateTime to)
            : base(Guid.NewGuid())
        {
            this.From = from;
            this.To = to;
        }

        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
    }
}
