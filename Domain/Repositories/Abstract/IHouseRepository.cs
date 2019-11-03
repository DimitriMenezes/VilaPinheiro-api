using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories.Abstract
{
    public interface IHouseRepository
    {
        House GetHouse(int id);
        IQueryable<House> GetAllHouses();
        int CreateHouse(House house);
        int UpdateHouse(House house);
        int RemoveHouse(int id);
    }
}
