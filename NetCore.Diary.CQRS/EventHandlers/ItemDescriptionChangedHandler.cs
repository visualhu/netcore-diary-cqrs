using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public class ItemDescriptionChangedHandler:INotificationHandler<ItemDescriptionChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemDescriptionChangedHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }
        
        public Task Handle(ItemDescriptionChangedEvent handle,CancellationToken token)
        {
            var item = _reportDatabase.GetById(handle.AggregateId);
            item.Description = handle.Description;
            item.Version = handle.Version;
            return Task.CompletedTask;
        }
    }
}