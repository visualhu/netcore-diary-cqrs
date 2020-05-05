using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public class ItemToChangedEventHandler:INotificationHandler<ItemToChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemToChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public Task Handle(ItemToChangedEvent handle, CancellationToken token)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.To = handle.To;
            item.Version = handle.Version;
            return Task.CompletedTask;
        }
    }
}