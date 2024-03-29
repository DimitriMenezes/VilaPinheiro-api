﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class House
    {
        public House()
        {
            Family = new HashSet<Family>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public decimal? Phone { get; set; }

        public virtual ICollection<Family> Family { get; set; }
    }
}
