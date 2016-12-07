using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSS_Ping_Pong_Backend.Data;
using NSS_Ping_Pong_Backend.Models;

namespace NSS_Ping_Pong_Backend.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {

        private NSSPingPongContext context;

        public PlayersController(NSSPingPongContext ctx)
        {
            context = ctx;
        }


        // GET api/players
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> players = from player in context.Player select player;

            if (players == null)
            {
                return NotFound();
            }

            return Ok(players);
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Player player = context.Player.Single(m => m.PlayerId == id);

                if (player == null)
                {
                    return NotFound();
                }

                return Ok(player);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/players
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
