using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Person
    {
        public Person()
        {
            Contact = new HashSet<Contact>();
            Family = new HashSet<Family>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Cpf { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<Contact> Contact { get; set; }
        public ICollection<Family> Family { get; set; }
    }
}
