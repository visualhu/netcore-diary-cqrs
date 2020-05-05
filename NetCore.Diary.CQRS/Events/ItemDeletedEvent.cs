using System;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemDeletedEvent:Event
    {
        public ItemDeletedEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}