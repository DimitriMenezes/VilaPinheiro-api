using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Context;
using VilaPinheiro.Services.Concrete;

namespace VilaPinheiro.Controllers
{

    [Route("api/Pessoa")]
    [ApiController]
    public class PersonController : ControllerBase    
    {
        public PersonController()
        {          
        }

        [HttpGet("{cpf}")]        
        public ActionResult ObterPessoa(string cpf)
        {
            var personService = new PersonService();

            var person = personService.ObterPessoa(cpf);
            return Ok(person);
        }
    }
}
