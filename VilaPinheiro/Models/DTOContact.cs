using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilaPinheiro.Models
{
    public class DTOContact
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public decimal? Cellphone1 { get; set; }
        public decimal? Cellphone2 { get; set; }
    }
}
