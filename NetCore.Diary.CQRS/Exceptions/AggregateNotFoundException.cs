using System;

namespace NetCore.Diary.CQRS.Exceptions
{
    public class AggregateNotFoundException: Exception
    {
        public AggregateNotFoundException(string message) : base(message) { }
    }
}