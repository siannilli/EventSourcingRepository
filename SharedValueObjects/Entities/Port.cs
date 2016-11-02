using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedDomainsObjects.ValueObjects;

namespace SharedDomainsObjects.Entities
{
    public class Port: BaseEntity
    {
        public string UNTACD { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public GeographicPoint Position { get; private set; }

        public Port(Guid id, string code, string name, string country, GeographicPoint point)
            : base(id)
        {
            this.UNTACD = code;
            this.Name = name;
            this.Country = country;
            this.Position = point;
        }

    }
}
