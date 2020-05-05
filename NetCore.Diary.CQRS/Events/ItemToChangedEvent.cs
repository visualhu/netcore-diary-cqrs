using System;
using System.Runtime;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemToChangedEvent:Event
    {
        public DateTime To { get; set; }

        public ItemToChangedEvent(Guid aggregateId, DateTime to)
        {
            AggregateId = aggregateId;
            To = to;
        }
    }
}