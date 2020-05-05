using System;

namespace NetCore.Diary.CQRS.Domain.Mementos
{
    public class DiaryItemMemento:BaseMemento
    {
        public DiaryItemMemento(string title, string description, DateTime from, DateTime to, int version)
        {
            Id = Id;
            Title = title;
            Description = description;
            From = from;
            To = to;
            Version = version;
            EventVersion = version;
        }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int EventVersion { get; set; }
    }
}