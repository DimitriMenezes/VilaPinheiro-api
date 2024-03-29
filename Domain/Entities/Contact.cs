﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public decimal? Cellphone1 { get; set; }
        public decimal? Cellphone2 { get; set; }

        public virtual Person Person { get; set; }
    }
}
