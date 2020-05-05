using System.Collections.Generic;
using NetCore.Diary.CQRS.Events;

namespace NetCore.Diary.CQRS.Domain
{
    public interface IEventProvider
    {
        void LoadsFromHistory(IEnumerable<Event> history);
        IEnumerable<Event> GetUncommittedChanges();
    }
}