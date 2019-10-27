using Domain.Context;
using Domain.Entities;
using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Models;
using VilaPinheiro.Services.Abstract;
using System.Data.Entity;

namespace VilaPinheiro.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private ModelContext _context;
        private IPersonRepository _personRepository;
        
        
        public PersonService()
        {            
            _personRepository = new PersonRepository();
        }        
       
        public DTOPerson ObterPessoa(string cpf)
        {
            var person = _personRepository.ObterPessoa(cpf);

            var dto = new DTOPerson
            {
                Birthday = person.Birthday,
                Cpf = person.Cpf,
                Id = person.Id,
                Name = person.Name,
                Nickname = person.Nickname
            };

            //AutoMapper.Mapper.CreateMap<Person,DTOPerson>(person);
            
            return dto;
        }

        public IQueryable<Person> ObterProximosAniversarios(int qtdDays)
        {           
            return  _personRepository.ObterPessoas().
                Where(u => u.Birthday.Value.AddYears(DateTime.Now.Year - u.Birthday.Value.Year) >= DateTime.Now.Date 
                && u.Birthday.Value.AddYears(DateTime.Now.Year - u.Birthday.Value.Year) <= DateTime.Now.Date.AddDays(qtdDays));            
        }
    }
}
