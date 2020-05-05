using System;
using NetCore.Diary.CQRS.Domain;

namespace NetCore.Diary.CQRS.Storage
{
    public interface IRepository<T> where T:AggregateRoot,new ()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}