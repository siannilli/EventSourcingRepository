using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseDomainObjects
{
    public interface IRepository<T, TIdentity> where T : IEventSourcedAggregate<TIdentity>
    {
        IEventSourcedAggregate<TIdentity> Get(System.Guid id, System.DateTime? date);
        void Save(T instance);
    }
}