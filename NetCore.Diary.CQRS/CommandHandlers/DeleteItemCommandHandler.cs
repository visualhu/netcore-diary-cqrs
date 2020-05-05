using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NetCore.Diary.CQRS.Commands;
using NetCore.Diary.CQRS.Domain;
using NetCore.Diary.CQRS.Storage;

namespace NetCore.Diary.CQRS.CommandHandlers
{
    public class DeleteItemCommandHandler:IRequestHandler<DeleteItemCommand,string>
    {
        private readonly IRepository<DiaryItem> _repository;

        public DeleteItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public Task<string> Handle(DeleteItemCommand command, CancellationToken token)
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
            aggregate.Delete();
            _repository.Save(aggregate,aggregate.Version);
            return Task.FromResult("Ok");
        }
    }
}