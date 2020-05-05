using NetCore.Diary.CQRS.Events;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent:Event
    {
        void Handle(TEvent handle);
    }
}