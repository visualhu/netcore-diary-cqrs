using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public class ItemDeletedEventHandler:INotificationHandler<ItemDeletedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemDeletedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public Task Handle(ItemDeletedEvent handle,CancellationToken token)
        {
            _reportDatabase.Delete(handle.AggregateId);
            return Task.CompletedTask;
        }
    }
}