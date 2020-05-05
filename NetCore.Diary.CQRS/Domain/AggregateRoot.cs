using System;
using System.Collections.Generic;
using System.Linq;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Utils;

namespace NetCore.Diary.CQRS.Domain
{
    public class AggregateRoot:IEventProvider
    {
        private readonly IList<Event> _changes;

        protected AggregateRoot()
        {
            _changes = new List<Event>();
        }

        public Guid Id { get; internal set; }
        public int Version { get; internal set; }
        public int EventVersion { get; set; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var @event in history)
            {
                ApplyChange(@event, false);
            }

            Version = history.Last().Version;
            EventVersion = Version;
        }

        protected void ApplyChange(Event @event)
        {
            ApplyChange(@event,true);
        }

        private void ApplyChange(Event @event, bool isNew)
        {
            dynamic d = this;
            d.Handle(Converter.ChangeTo(@event, @event.GetType()));

            if (isNew)
            {
                _changes.Add(@event);
            }
        }
    }
}