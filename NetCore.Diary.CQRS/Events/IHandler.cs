namespace NetCore.Diary.CQRS.Events
{
    public interface IHandler<TEvent> where TEvent:Event
    {
        void Handle(TEvent e);
    }
}