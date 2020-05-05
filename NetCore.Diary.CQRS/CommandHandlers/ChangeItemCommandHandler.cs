using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Commands;
using NetCore.Diary.CQRS.Domain;
using NetCore.Diary.CQRS.Reporting;
using NetCore.Diary.CQRS.Storage;

namespace NetCore.Diary.CQRS.CommandHandlers
{
    //public class ChangeItemCommandHandler:ICommandHandler<ChangeItemCommand>
    public class ChangeItemCommandHandler:IRequestHandler<ChangeItemCommand,string>
    {
        private readonly IRepository<DiaryItem> _repository;

        public ChangeItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(ChangeItemCommand command,CancellationToken token)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var aggregate = _repository.GetById(command.Id);
            if (aggregate.Title != command.Title)
            {
                aggregate.ChangeTitle(command.Title);
            }

            if (aggregate.Description != command.Description)
            {
                aggregate.ChangeDescription((command.Description));
            }

            if (aggregate.From != command.From)
            {
                aggregate.ChangeFrom(command.From);
            }

            if (aggregate.To != command.To)
            {
                aggregate.ChangeTo(command.To);
            }
            
            _repository.Save(aggregate, command.Version);
            return Task.FromResult("Ok.");
        }
    }
}