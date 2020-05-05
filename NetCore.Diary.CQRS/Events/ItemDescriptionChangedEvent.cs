using System;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemDescriptionChangedEvent:Event,INotification
    {
        public string Description { get; set; }

        public ItemDescriptionChangedEvent(Guid aggregateId, string description)
        {
            AggregateId = aggregateId;
            Description = description;
        }
    }
}