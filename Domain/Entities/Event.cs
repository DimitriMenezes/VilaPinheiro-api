using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Event
    {
        public Event()
        {
            EventInvitation = new HashSet<EventInvitation>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPrivate { get; set; }

        public virtual ICollection<EventInvitation> EventInvitation { get; set; }
    }
}
