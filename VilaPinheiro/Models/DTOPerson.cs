using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilaPinheiro.Models
{
    public class DTOPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Cpf { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DTOContact Contact { get; set; }
    }
}
