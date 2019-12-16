using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.Context;
using VilaPinheiro.Services.Concrete;
using VilaPinheiro.Services.Abstract;
using VilaPinheiro.Models;

namespace VilaPinheiro.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase    
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }
        /// <summary>
        /// Obtém uma pessoa pelo cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("{cpf}")]        
        public ActionResult GetPersonByCpf(string cpf)
        {
            if (cpf == null)
                return BadRequest();
                       
            var person = personService.GetPersonByCpf(cpf);

            if (person == null)
                return NoContent();
            
            return Ok(person);
        }
        /// <summary>
        /// Cadastra uma pessoa e seu contato
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("")]
        public ActionResult CreatePerson(DTOPerson dto)
        {
            try
            {
                personService.CreatePerson(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }           
        }
        /// <summary>
        /// Obtém os aniversários dos próximos 15 dias
        /// </summary>
        /// <returns></returns>
        [HttpGet("Birthdays")]
        public ActionResult GetNextBirthdays()
        {
            var birthdays = personService.GetNextBirthdays(15);

            if (!birthdays.Any())
                return NoContent();

            return Ok(birthdays);
        }
    }
}
