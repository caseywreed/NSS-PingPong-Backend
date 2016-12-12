﻿using System;
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

        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public int Team { get; set; }
        public bool? Won { get; set; }
        public double? PointDiff { get; set; }

        public GamePlayer()
        {

        }

        public GamePlayer(int playerId, int TeamInt, int gameId)
        {
            PlayerId = playerId;
            GameId = gameId;
            Team = TeamInt;
        }
    }
}
