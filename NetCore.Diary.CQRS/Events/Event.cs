using System;
using MediatR;

namespace NetCore.Diary.CQRS.Events
{
    // public class Event:IEvent
    public class Event:INotification
    {
        public int Version;
        public Guid AggregateId { get; set; }
        public Guid Id { get; private set; }
    }
}