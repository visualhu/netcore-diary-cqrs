using NetCore.Diary.CQRS.CommandHandlers;
using NetCore.Diary.CQRS.Commands;

namespace NetCore.Diary.CQRS.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}