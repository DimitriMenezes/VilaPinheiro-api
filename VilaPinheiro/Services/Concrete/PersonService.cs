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
using VilaPinheiro.Util;

namespace VilaPinheiro.Services.Concrete
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IContactRepository _contactRepository;
        
        public PersonService(IPersonRepository personRepository, IContactRepository contactRepository)
        {            
            _personRepository = new PersonRepository();
            _contactRepository = new ContactRepository();
        }        
       
        public DTOPerson GetPersonByCpf(string cpf)
        {
            var person = _personRepository.GetByCpf(cpf);

            if (person == null)
                return null;

            var dto = new DTOPerson
            {
                DateOfBirth = person.DateOfBirth,
                Cpf = person.Cpf,
                Id = person.Id,
                Name = person.Name,
                Nickname = person.Nickname,
                Contact = new DTOContact
                {
                    
                }
            };

            //Mapper.Map<Person,DTOPerson>(person, dto);
            
            return dto;
        }

        public IList<DTONextBirthday> GetNextBirthdays(int qtdDays)
        {           
            var query =  _personRepository.GetAll().
                Where(u => u.DateOfBirth.AddYears(DateTime.Now.Year - u.DateOfBirth.Year) >= DateTime.Now.Date 
                && u.DateOfBirth.AddYears(DateTime.Now.Year - u.DateOfBirth.Year) <= DateTime.Now.Date.AddDays(qtdDays));

            var result = new List<DTONextBirthday>();

            foreach(var person in query)
            {
                result.Add(new DTONextBirthday
                {
                    Birthday = person.DateOfBirth,
                    PersonId = person.Id,
                    PersonName = person.Name,
                    PersonNickName = person.Nickname
                });
            }

            return result;
        }

        public void CreatePerson(DTOPerson dto)
        {
            var person = new Person
            {
                Cpf = dto.Cpf,
                DateOfBirth = dto.DateOfBirth,
                Name = dto.Name,
                Nickname = dto.Nickname
            };

            _personRepository.Insert(person);

            if(dto.Contact != null)
            {
                var contact = new Contact
                {
                    PersonId = person.Id,
                    Email = dto.Contact.Email,
                    Cellphone1 = dto.Contact.Cellphone1,
                    Cellphone2 = dto.Contact.Cellphone2
                };
                _contactRepository.Insert(contact);
            }
        }        
    }
}
