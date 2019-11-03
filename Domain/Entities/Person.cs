using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Person
    {
        public Person()
        {
            Contact = new HashSet<Contact>();
            EventInvitation = new HashSet<EventInvitation>();
            Family = new HashSet<Family>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Cpf { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<EventInvitation> EventInvitation { get; set; }
        public virtual ICollection<Family> Family { get; set; }
    }
}
