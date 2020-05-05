using System;
using System.Runtime;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemToChangedEvent:Event,INotification
    {
        public DateTime To { get; set; }

        public ItemToChangedEvent(Guid aggregateId, DateTime to)
        {
            AggregateId = aggregateId;
            To = to;
        }
    }
}