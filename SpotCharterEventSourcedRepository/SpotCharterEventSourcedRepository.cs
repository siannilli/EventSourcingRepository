using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventSourcePostgresRepository;
using SharedShippingDomainsObjects.ValueObjects;
using BaseDomainObjects.Events;

using SpotCharterDomain;

using NpgsqlTypes;

namespace SpotCharterEventSourcedRepository
{
    public class SpotCharterEventSourcedRepository : PostgresSQLEventSourceRepository<SpotCharter, SpotCharterId>, ISpotCharterRepository
    {
        public SpotCharterEventSourcedRepository(string database, string login, string password, string tableName, string applicationName = "SpotCharterRepository", string host = "localhost", int port = 5432) 
            : base(database, login, password, tableName, applicationName, host, port)            
        {

        }

        public override SpotCharter Get(SpotCharterId id)
        {
            var eventStream = this.GetEventStream(id);
            return new SpotCharter(eventStream);
        }

        protected override IDictionary<string, Tuple<NpgsqlTypes.NpgsqlDbType, object>> parseKeyValueFields(SpotCharterId identity)
        {
            return new Dictionary<string, Tuple<NpgsqlTypes.NpgsqlDbType, object>> { { "aggregate_id", new Tuple<NpgsqlTypes.NpgsqlDbType, object>(NpgsqlDbType.Uuid, identity.Value) } };
        }
    }
}
