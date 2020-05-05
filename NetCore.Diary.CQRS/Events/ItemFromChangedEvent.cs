using System;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemFromChangedEvent:Event,INotification
    {
        public DateTime From { get; set; }

        public ItemFromChangedEvent(Guid aggregateId, DateTime from)
        {
            AggregateId = aggregateId;
            From = from;
        }
    }
}