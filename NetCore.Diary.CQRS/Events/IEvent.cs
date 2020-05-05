using System;

namespace NetCore.Diary.CQRS.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}