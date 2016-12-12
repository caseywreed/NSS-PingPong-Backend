using NSS_Ping_Pong_Backend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NSS_Ping_Pong_Backend.Models
{
    public class Stats
    {
        [Key]
        public int StatsId { get; set; }
        public int PlayerId { get; set; }

        //Core Stats
        public double Wins { get; set; }
        public double Losses { get; set; }
        public double Games { get; set; }

        //Computed Stats
        public double? WinPercentage { get; set; }
        public double? AvgPointDiff { get; set; }
        public double? Rating { get; set; }

        public void CalculateStats(NSSPingPongContext context)
        {
            WinPercentage = (Wins / Games);

            var gps = context.GamePlayer.Where(g => g.PlayerId == PlayerId);

            Double pointDiffCounter = 0;
            Double numOfGames = gps.Count();
            foreach (GamePlayer gp in gps)
            {
                pointDiffCounter = pointDiffCounter + (double)gp.PointDiff;
            }

            AvgPointDiff = (pointDiffCounter / numOfGames);

        }

        public Stats()
        {
            var rnd = new Random();
            Wins = rnd.Next(1, 101);
            Losses = rnd.Next(1, 101);
            Games = Wins + Losses;
        }
    }
}
