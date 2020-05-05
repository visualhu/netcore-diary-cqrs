using NetCore.Diary.CQRS.Domain.Mementos;

namespace NetCore.Diary.CQRS.Storage.Memento
{
    public interface IOriginator
    {
        BaseMemento GetMemento();
        void SetMemento(BaseMemento memento);
    }
}