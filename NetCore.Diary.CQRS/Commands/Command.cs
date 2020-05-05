using System;
using MediatR;

namespace NetCore.Diary.CQRS.Commands
{
    // public class Command:ICommand
    public class Command:IRequest<string>
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }

        public Command(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}