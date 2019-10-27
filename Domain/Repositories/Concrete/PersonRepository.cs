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
    public class PersonRepository : IPersonRepository
    {
        private readonly ModelContext _context;

        public PersonRepository()
        {
            _context = new ModelContext();
        }

        public PersonRepository(ModelContext context)
        {
            _context = context;
        }

        public IQueryable<Person> ObterPessoas()
        {
            return _context.Person;
        }

        public Person ObterPessoa(string cpf)
        {
            return _context.Person.Where(i => i.Cpf ==cpf).FirstOrDefault();
        }
    }
}
