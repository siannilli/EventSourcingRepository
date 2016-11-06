using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseDomainObjects;

namespace EventSourcePostgresRepository
{
    public abstract class EventSourcePostgresRepository<T, TIdentity> : IEventSourceRepository<T, TIdentity> where T : IEventSourcedAggregate<TIdentity>
    {

        private readonly string connectionString;
        private readonly string tableName;

        public EventSourcePostgresRepository(            
            string database,
            string login, 
            string password,             
            string tableName,
            string applicationName = "cqrs+es client",
            string host = "localhost",
            int port = 5432)
        {
            this.connectionString = $"Host={host};Port={port};Username={login};Password={password};Application name={applicationName};Database={database}";
            this.tableName = tableName;
        }

        T IEventSourceRepository<T, TIdentity>.Get(TIdentity id)
        {
            throw new NotImplementedException();
        }

        void IEventSourceRepository<T, TIdentity>.Save(T instance)
        {
            
            throw new NotImplementedException();
        }

        protected abstract IDictionary<string, string> parseKeyValueFields(TIdentity identity);
    }
}
