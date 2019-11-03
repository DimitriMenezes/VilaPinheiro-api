using Domain.Context;
using Domain.Entities;
using Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repositories.Concrete
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ModelContext _context;

        public House GetHouse(int id)
        {
            return _context.House.Where(i => i.Id == id).FirstOrDefault();
        }

        public IQueryable<House> GetAllHouses()
        {
            return _context.House;
        }

        public int CreateHouse(House house)
        {
            _context.House.Add(house);
            return _context.SaveChanges();
        }

        public int UpdateHouse(House house)
        {
            _context.House.Update(house);
            return _context.SaveChanges();
        }

        public int RemoveHouse(int id)
        {
            var house = _context.House.Find(id);
            _context.House.Remove(house);
            return _context.SaveChanges();
        }
    }
}
