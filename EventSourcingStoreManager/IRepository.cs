using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventSourcingStoreBase
{
    public interface IRepository<T> where T : IAggregate
    {
        IAggregate Get(System.Guid id, System.DateTime? date);
        void Save(T instance);
    }
}