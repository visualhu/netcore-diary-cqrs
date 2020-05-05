using System;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    public class ItemCreatedEvent:Event,INotification
    {
        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }

        public ItemCreatedEvent(Guid aggregatedId, string title, string description, DateTime from, DateTime to)
        {
            AggregateId = aggregatedId;
            Title = title;
            From = from;
            To = to;
            Description = description;
        }
    }
}