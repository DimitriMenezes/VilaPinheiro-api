using Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Models;
using VilaPinheiro.Services.Abstract;

namespace VilaPinheiro.Services.Concrete
{
    public class HouseService : IHouseService
    {
        private IPersonRepository _personRepository;
        private IHouseRepository _houseRepository;
        public void InsertHouse(DTOHouse dto)
        {            

            
        }
    }
}
