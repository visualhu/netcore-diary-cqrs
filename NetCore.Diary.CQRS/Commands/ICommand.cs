using System;

namespace NetCore.Diary.CQRS.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}