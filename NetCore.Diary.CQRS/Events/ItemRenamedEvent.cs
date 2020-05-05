using System;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemRenamedEvent:Event
    {
        public string Title { get; set; }

        public ItemRenamedEvent(Guid aggregateId, string title)
        {
            AggregateId = aggregateId;
            Title = title;
        }
    }
}