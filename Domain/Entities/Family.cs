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

        public FamilyRelationship FamilyRelationship { get; set; }
        public House House { get; set; }
        public Person Person { get; set; }
    }
}
