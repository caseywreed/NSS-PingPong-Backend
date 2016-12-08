using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSS_Ping_Pong_Backend.Models
{
    public class GamePlayer
    {
        [Key]
        public int GamePlayerId { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }

        public int Team { get; set; }
        public bool? Won { get; set; }
        public int? PointDiff { get; set; }

        public GamePlayer(Player player, Game game)
        {
            Player = player;
            Game = game;
        }
    }
}
