using NetCore.Diary.CQRS.Commands;

namespace NetCore.Diary.CQRS.CommandHandlers
{
    public interface ICommandHandler<TCommand> where TCommand:Command
    {
        void Execute(TCommand command);
    }
}