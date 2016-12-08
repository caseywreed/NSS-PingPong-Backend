using Microsoft.AspNetCore.Mvc;
using NSS_Ping_Pong_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NSS_Ping_Pong_Backend.Data;

namespace NSS_Ping_Pong_Backend.Controllers
{
    public class ReportsController
    {
        // Two Player Game Report
        // POST api/Reports
        [HttpPost]
        public IActionResult Post([FromBody]Player playerOne, [FromBody] Player playerTwo)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Game g = new Game();
            GamePlayer gpOne = new GamePlayer(playerOne, 1, g.GameId);
            GamePlayer gpTwo = new GamePlayer(playerTwo, 2, g.GameId);
            return Ok(game);
        }

        // Four Player Game Report
        // POST api/Reports
        [HttpPost]
        public IActionResult Post([FromBody]Player playerOne, [FromBody] Player playerTwo, [FromBody]Player playerThree, [FromBody] Player playerFour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(game);
        }
    }
}
