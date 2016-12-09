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
    public class ReportsController : Controller
    {

        private NSSPingPongContext context;

        public ReportsController(NSSPingPongContext ctx)
        {
            context = ctx;
        }

        // Two Player Game Report
        // POST api/Reports

        [HttpPost]
        [Route("TwoPlayerGame")]
        public IActionResult Post([FromBody]TwoPlayerGame model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Game game = new Game();

            var gamePlayers = new GamePlayer[]
            {
                new GamePlayer(model.playerOneId, 1, game.GameId),
                new GamePlayer(model.playerTwoId, 2, game.GameId)
            };

            foreach (GamePlayer g in gamePlayers)
            {
                context.GamePlayer.Add(g);
            }

            game.GamePlayers = gamePlayers.ToList();
            game.TeamOneScore = model.teamOneScore;
            game.TeamTwoScore = model.teamTwoScore;

            //Check scores against each other to calculate Point Differential
            //and decide who won

            if (model.teamOneScore > model.teamTwoScore)
            {
                gamePlayers[0].Won = true;
                gamePlayers[0].PointDiff = (model.teamOneScore - model.teamTwoScore);
                gamePlayers[1].Won = false;
                gamePlayers[1].PointDiff = (model.teamTwoScore - model.teamOneScore);
            }
            else
            {
                gamePlayers[0].Won = false;
                gamePlayers[0].PointDiff = (model.teamOneScore - model.teamTwoScore);
                gamePlayers[1].Won = true;
                gamePlayers[1].PointDiff = (model.teamTwoScore - model.teamOneScore);
            }

            context.Game.Add(game);
            context.SaveChanges();
            return Ok(game);
        }

        [HttpPost]
        [Route("FourPlayerGame")]
        public IActionResult Post([FromBody]FourPlayerGame model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Game game = new Game();

            var gamePlayers = new GamePlayer[]
            {
                new GamePlayer(model.playerOneId, 1, game.GameId),
                new GamePlayer(model.playerTwoId, 1, game.GameId),
                new GamePlayer(model.playerThreeId, 2, game.GameId),
                new GamePlayer(model.playerFourId, 2, game.GameId)
            };

            foreach (GamePlayer g in gamePlayers)
            {
                context.GamePlayer.Add(g);
            }

            game.GamePlayers = gamePlayers.ToList();
            game.TeamOneScore = model.teamOneScore;
            game.TeamTwoScore = model.teamTwoScore;

            //Check scores against each other to calculate Point Differential
            //and decide who won

            if (model.teamOneScore > model.teamTwoScore)
            {
                //Team One Win
                gamePlayers[0].Won = true;
                gamePlayers[0].PointDiff = (model.teamOneScore - model.teamTwoScore);
                gamePlayers[1].Won = true;
                gamePlayers[1].PointDiff = (model.teamOneScore - model.teamTwoScore);
                //Team Two Loss
                gamePlayers[2].Won = false;
                gamePlayers[2].PointDiff = (model.teamTwoScore - model.teamOneScore);
                gamePlayers[3].Won = false;
                gamePlayers[3].PointDiff = (model.teamTwoScore - model.teamOneScore);
            }
            else
            {
                //Team One Loss
                gamePlayers[0].Won = false;
                gamePlayers[0].PointDiff = (model.teamOneScore - model.teamTwoScore);
                gamePlayers[1].Won = false;
                gamePlayers[1].PointDiff = (model.teamOneScore - model.teamTwoScore);
                //Team Two Win
                gamePlayers[2].Won = true;
                gamePlayers[2].PointDiff = (model.teamTwoScore - model.teamOneScore);
                gamePlayers[3].Won = true;
                gamePlayers[3].PointDiff = (model.teamTwoScore - model.teamOneScore);
            }

            context.Game.Add(game);
            context.SaveChanges();
            return Ok(game);
        }
    }
}

