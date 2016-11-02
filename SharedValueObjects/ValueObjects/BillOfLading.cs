using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDomainsObjects.ValueObjects
{
    public class BillOfLading
    {
        public DateTime Date { get; private set; }
        public CargoQuantity Quantity { get; private set; }
        public string DocReference { get; private set; }
    }
}
