using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class EventInvitation
    {
        public int PersonId { get; set; }
        public int EventId { get; set; }

        public virtual Event Event { get; set; }
        public virtual Person Person { get; set; }
    }
}
