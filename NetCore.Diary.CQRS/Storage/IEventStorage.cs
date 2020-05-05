using System;
using System.Collections.Generic;
using NetCore.Diary.CQRS.Domain;
using NetCore.Diary.CQRS.Domain.Mementos;
using NetCore.Diary.CQRS.Events;

namespace NetCore.Diary.CQRS.Storage
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);
        void Save(AggregateRoot aggregate);
        T GetMemento<T>(Guid aggregateId) where T : BaseMemento;
        void SaveMemento(BaseMemento memento);
    }
}