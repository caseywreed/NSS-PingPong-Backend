using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NSS_Ping_Pong_Backend.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        // GET api/games
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/games
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/games/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
