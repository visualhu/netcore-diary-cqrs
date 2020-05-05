using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Reporting;

namespace NetCore.Diary.CQRS.EventHandlers
{
    //public class ItemCreatedEventHandler:IEventHandler<ItemCreatedEvent>
    public class ItemCreatedEventHandler:INotificationHandler<ItemCreatedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemCreatedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public Task Handle(ItemCreatedEvent handle,CancellationToken token)
        {
            var item = new DiaryItemDto
            {
                Id = handle.AggregateId,
                Description = handle.Description,
                From = handle.From,
                Title = handle.Title,
                To = handle.To,
                Version = handle.Version
            };

            _reportDatabase.Add(item);
            return Task.CompletedTask;
        }

    }
}