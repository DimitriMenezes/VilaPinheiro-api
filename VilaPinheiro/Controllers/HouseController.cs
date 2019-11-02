using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult CreateHouse()
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
