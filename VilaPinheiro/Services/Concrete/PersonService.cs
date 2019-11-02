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
        private IPersonRepository _personRepository;        
        
        public PersonService()
        {            
            _personRepository = new PersonRepository();
        }        
       
        public DTOPerson ObterPessoa(string cpf)
        {
            var person = _personRepository.ObterPessoa(cpf);

            if (person == null)
                return null;

            var dto = new DTOPerson
            {
                Birthday = person.Birthday,
                Cpf = person.Cpf,
                Id = person.Id,
                Name = person.Name,
                Nickname = person.Nickname
            };

            //Mapper.Map<Person,DTOPerson>(person, dto);
            
            return dto;
        }

        public IList<DTONextBirthday> ObterProximosAniversarios(int qtdDays)
        {           
            var query =  _personRepository.ObterPessoas().
                Where(u => u.Birthday.Value.AddYears(DateTime.Now.Year - u.Birthday.Value.Year) >= DateTime.Now.Date 
                && u.Birthday.Value.AddYears(DateTime.Now.Year - u.Birthday.Value.Year) <= DateTime.Now.Date.AddDays(qtdDays));

            var result = new List<DTONextBirthday>();

            foreach(var person in query)
            {
                result.Add(new DTONextBirthday
                {
                    Birthday = person.Birthday.Value,
                    PersonId = person.Id,
                    PersonName = person.Name,
                    PersonNickName = person.Nickname
                }) ;
            }

            return result;
        }
    }
}
