using System;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemRenamedEvent:Event,INotification
    {
        public string Title { get; set; }

        public ItemRenamedEvent(Guid aggregateId, string title)
        {
            AggregateId = aggregateId;
            Title = title;
        }
    }
}