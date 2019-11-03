using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Models;

namespace VilaPinheiro.Services.Abstract
{
    public interface IHouseService
    {
        void InsertHouse(DTOHouse dto);
    }
}
