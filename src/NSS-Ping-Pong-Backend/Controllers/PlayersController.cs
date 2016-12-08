using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSS_Ping_Pong_Backend.Data;
using NSS_Ping_Pong_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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

            foreach (Player p in players)
            {
                p.Stats.CalculateStats();
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
                player.Stats.CalculateStats();
                return Ok(player);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/players
        [HttpPost]
        public IActionResult Post([FromBody]Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Player.Add(player);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PlayerExists(player.PlayerId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return Ok(player);
        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (player.PlayerId != id)
            {
                return BadRequest(player);
            }
            try
            {
                context.Player.Update(player);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            return Ok(player);
        }

        // PATCH api/players/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Player player = context.Player.Single(m => m.PlayerId == id);

            if (player == null)
            {
                return NotFound();
            }
            else
            {
                context.Player.Remove(player);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (PlayerExists(player.PlayerId))
                    {
                        return new StatusCodeResult(StatusCodes.Status403Forbidden);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return context.Player.Count(e => e.PlayerId == id) > 0;
        }
    }
}
