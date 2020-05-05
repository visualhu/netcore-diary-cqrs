using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public class ItemFromChangedEventHandler:INotificationHandler<ItemFromChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemFromChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public Task Handle(ItemFromChangedEvent handle,CancellationToken token)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.From = handle.From;
            item.Version = handle.Version;
            return Task.CompletedTask;
        }
    }
}