using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Context;
using VilaPinheiro.Services.Concrete;
using VilaPinheiro.Services.Abstract;

namespace VilaPinheiro.Controllers
{

    [Route("api/Pessoa")]
    [ApiController]
    public class PersonController : ControllerBase    
    {
        private IPersonService personService;
        public PersonController()
        {
            personService = new PersonService();
        }

        [HttpGet("{cpf}")]        
        public ActionResult GetPerson(string cpf)
        {
            if (cpf == null)
                return BadRequest();
                       
            var person = personService.ObterPessoa(cpf);

            if (person == null)
                return NoContent();
            
            return Ok(person);
        }


        [HttpGet("Birthdays")]
        public ActionResult GetNextBirthdays()
        {
            var birthdays = personService.ObterProximosAniversarios(15);

            if (!birthdays.Any())
                return NoContent();

            return Ok(birthdays);
        }
    }
}
