using Domain.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class PersonRepository : BaseRepository<Person> , IPersonRepository
    {
        public Person GetByCpf(string cpf)
        {
            return dbSet.Where(i => i.Cpf == cpf).FirstOrDefault();
        }
    }
}
