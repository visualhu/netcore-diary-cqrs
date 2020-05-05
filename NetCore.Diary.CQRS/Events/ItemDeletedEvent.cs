using System;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemDeletedEvent:Event,INotification
    {
        public ItemDeletedEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}