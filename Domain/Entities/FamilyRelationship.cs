using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class FamilyRelationship
    {
        public FamilyRelationship()
        {
            Family = new HashSet<Family>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Family> Family { get; set; }
    }
}
