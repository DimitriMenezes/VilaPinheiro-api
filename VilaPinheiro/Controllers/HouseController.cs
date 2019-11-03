using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilaPinheiro.Models;

namespace VilaPinheiro.Controllers
{
    [Route("api/House")]
    [ApiController]
    public class HouseController : ControllerBase
    {

        [HttpGet()]
        public ActionResult GetAllHouses()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetHouse(int id)
        {
            return Ok();
        }

        [HttpPost()]
        public ActionResult CreateHouse(DTOHouse dto)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHouse(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHouse(int id)
        {
            return Ok();
        }

    }
}
