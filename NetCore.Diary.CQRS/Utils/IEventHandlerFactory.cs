using System.Collections.Generic;
using NetCore.Diary.CQRS.EventHandlers;
using NetCore.Diary.CQRS.Events;

namespace NetCore.Diary.CQRS.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T : Event;
    }
}