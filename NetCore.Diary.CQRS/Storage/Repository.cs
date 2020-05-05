using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NetCore.Diary.CQRS.Domain;
using NetCore.Diary.CQRS.Domain.Mementos;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Storage.Memento;

namespace NetCore.Diary.CQRS.Storage
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStorage _storage;
        private readonly object _lockStorage = new object();

        public Repository(IEventStorage storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int expectedVersion)
        {
            if (!aggregate.GetUncommittedChanges().Any()) return;
            lock (_lockStorage)
            {
                var item = new T();
                if (expectedVersion != -1)
                {
                    item = GetById(aggregate.Id);
                    if (item.Version != expectedVersion)
                    {
                        throw new DBConcurrencyException($"Aggregate {item.Id} has been previously modified.");
                    }
                }

                _storage.Save(aggregate);
            }
        }

        public T GetById(Guid id)
        {
            IEnumerable<Event> events;
            if (_storage == null) return new T();
            var memento = _storage.GetMemento<BaseMemento>(id);
            events = memento != null
                ? _storage.GetEvents(id).Where(p => p.Version >= memento.Version)
                : _storage.GetEvents(id);
            var obj = new T();
            if (memento != null)
            {
                ((IOriginator) obj).SetMemento(memento);
            }

            obj.LoadsFromHistory(events);
            return obj;
        }
    }

}
