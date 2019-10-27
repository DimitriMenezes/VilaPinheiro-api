using Domain.Context;
using Domain.Entities;
using Domain.Repositories.Abstract;
using Domain.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Services.Abstract;

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
       
        public Person ObterPessoa(string cpf)
        {
            return _personRepository.ObterPessoa(cpf);
        }

        public void ObterProximosAniversarios()
        {
            throw new NotImplementedException();
        }
    }
}
