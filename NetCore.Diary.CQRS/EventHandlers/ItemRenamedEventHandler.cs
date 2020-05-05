using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public class ItemRenamedEventHandler:INotificationHandler<ItemRenamedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemRenamedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public Task Handle(ItemRenamedEvent handle, CancellationToken token)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.Title = handle.Title;
            item.Version = handle.Version;
            return Task.CompletedTask;
        }
    }
}