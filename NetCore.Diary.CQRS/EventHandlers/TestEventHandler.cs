using System;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Events;

namespace NetCore.Diary.CQRS.EventHandlers
{
    public class TestEventHandler:INotificationHandler<TestEvent>
    {
        public Task Handle(TestEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("It's OK.");
            return Task.CompletedTask;
        }
    }
}