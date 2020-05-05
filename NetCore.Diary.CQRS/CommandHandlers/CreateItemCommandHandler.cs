using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Commands;
using NetCore.Diary.CQRS.Domain;
using NetCore.Diary.CQRS.Storage;

namespace NetCore.Diary.CQRS.CommandHandlers
{
    public class CreateItemCommandHandler:IRequestHandler<CreateItemCommand,string>
    {
        private readonly IRepository<DiaryItem> _repository;

        public CreateItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(CreateItemCommand command,CancellationToken token)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            
            var aggregate = new DiaryItem(command.Id,command.Title,command.From,command.To,command.Description);
            aggregate.Version = -1;
            _repository.Save(aggregate,aggregate.Version);
            return Task.FromResult("Ok");
        }
    }
}