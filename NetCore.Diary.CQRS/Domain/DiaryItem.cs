using System;
using System.IO;
using NetCore.Diary.CQRS.Domain.Mementos;
using NetCore.Diary.CQRS.Events;
using NetCore.Diary.CQRS.Storage.Memento;

namespace NetCore.Diary.CQRS.Domain
{
    public class DiaryItem:AggregateRoot,
        IHandle<ItemCreatedEvent>,
        IHandle<ItemRenamedEvent>,
        IHandle<ItemFromChangedEvent>,
        IHandle<ItemToChangedEvent>,
        IHandle<ItemDescriptionChangedEvent>,
        IOriginator
    {

        public DiaryItem()
        {
            
        }
        public  DiaryItem(Guid id,string title, DateTime @from, DateTime to, string description)
        {
            ApplyChange(new ItemCreatedEvent(id,title,description,from,to));
        }

        public void ChangeTitle(string title)
        {
            ApplyChange(new ItemRenamedEvent(Id,title));
        }

        public void ChangeDescription(string description)
        {
            ApplyChange(new ItemDescriptionChangedEvent(Id,description));
        }

        public void ChangeFrom(DateTime from)
        {
            ApplyChange(new ItemFromChangedEvent(Id,from));
        }

        public void ChangeTo(DateTime to)
        {
            ApplyChange(new ItemToChangedEvent(Id,to));
        }

        public void Delete()
        {
            ApplyChange(new ItemDeletedEvent(Id));
        }

        public void Handle(ItemCreatedEvent e)
        {
            Title = e.Title;
            From = e.From;
            To = e.To;
            Description = e.Description;
            Version = e.Version;
            Id = e.Id;

        }

        public void Handle(ItemDescriptionChangedEvent e)
        {
            Description = e.Description;
        }

        public void Handle(ItemFromChangedEvent e)
        {
            From = e.From;
        }

        public void Handle(ItemRenamedEvent e)
        {
            Title = e.Title;
        }

        public void Handle(ItemToChangedEvent e)
        {
            To = e.To;
        }

        public BaseMemento GetMemento()
        {
            return new DiaryItemMemento(Title,Description,From,To,Version);
        }

        public void SetMemento(BaseMemento memento)
        {
            Title = ((DiaryItemMemento) memento).Title;
            Description = ((DiaryItemMemento) memento).Description;
            From = ((DiaryItemMemento) memento).From;
            To = ((DiaryItemMemento) memento).To;
            Version = memento.Version;
            Id = memento.Id;
        }

        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }
        
        
        
    }
}