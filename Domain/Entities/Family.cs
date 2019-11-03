using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Family
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int PersonId { get; set; }
        public int FamilyRelationshipId { get; set; }

        public virtual FamilyRelationship FamilyRelationship { get; set; }
        public virtual House House { get; set; }
        public virtual Person Person { get; set; }
    }
}
