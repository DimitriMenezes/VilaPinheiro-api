using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilaPinheiro.Models
{
    public class DTONextBirthday
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonNickName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
