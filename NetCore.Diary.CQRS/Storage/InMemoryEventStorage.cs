using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using NetCore.Diary.CQRS.Domain;
using NetCore.Diary.CQRS.Domain.Mementos;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Exceptions;
using NetCore.Diary.CQRS.Storage.Memento;
using NetCore.Diary.CQRS.Utils;

namespace NetCore.Diary.CQRS.Storage
{
    public class InMemoryEventStorage:IEventStorage
    {
        private List<Event> _events;
        private List<BaseMemento> _mementoes;

        private readonly IMediator _mediator;

        public InMemoryEventStorage(IMediator mediator)
        {
            _events = new List<Event>();
            _mementoes = new List<BaseMemento>();
            _mediator = mediator;
        }

        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            var events = _events.Where(p => p.AggregateId == aggregateId).Select(p => p).ToList();
            if (!events.Any())
                throw new AggregateNotFoundException($"Aggregate with id: {aggregateId} is not found.");

            return events;

        }

        public void Save(AggregateRoot aggregate)
        {
            var uncommittedChanges = aggregate.GetUncommittedChanges().ToList();
            var version = aggregate.Version;

            foreach (var @event in uncommittedChanges)
            {
                version++;
                if (version > 2)
                {
                    if (version % 3 == 0)
                    {
                        var originator = (IOriginator) aggregate;
                        var memento = originator.GetMemento();
                        memento.Version = version;
                        SaveMemento(memento);
                    }
                }

                @event.Version = version;
                _events.Add(@event);
            }

            foreach (var @event in uncommittedChanges)
            {
                var destEvent = Converter.ChangeTo(@event, @event.GetType());
                _mediator.Publish(destEvent);
            }
        }

        public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
        {
            var memento = _mementoes.Where(p => p.Id == aggregateId).Select(p => p).LastOrDefault();
            return (T) memento;
        }

        public void SaveMemento(BaseMemento memento)
        {
            _mementoes.Add(memento);
        }
    }
}