using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObOpg1;
using ObOpg4.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ObOpg4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private BeerManager _manager = new BeerManager(new List<Beer>()
        {
            new Beer(1,"Carlsberg", 15,5),
            new Beer(1,"Tuborg", 13.5,5),
            new Beer(1,"Corona", 20,8),
            new Beer(1,"Bud Light", 20,3)
        });

        // GET: api/<BeerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Beer>> Get()
        {
            return Ok(_manager.GetAll());
        }

        // GET api/<BeerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Beer> Get(int id)
        {
            Beer beer = _manager.GetById(id);
            if(beer == null)
            {
                return NotFound("Id not found : " + id);
            }
            else
            {
                return Ok(beer);
            }
        }

        // POST api/<BeerController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Beer> Post([FromBody] Beer value)
        {
            try
            {
                Beer b = _manager.Post(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + b.Id;
                return Created(uri, b);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BeerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Beer value)
        {
            _manager.Update(id, value);
        }

        // DELETE api/<BeerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manager.Delete(id);
        }
    }
}
