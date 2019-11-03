using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilaPinheiro.Models
{
    public class DTOHouse
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Phone { get; set; }
        public List<DTOPerson> Residents { get; set; }
    }
}
