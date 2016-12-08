using System;
using System.ComponentModel.DataAnnotations;

namespace NSS_Ping_Pong_Backend.Models
{
    public class Stats
    {
        [Key]
        public int StatsId { get; set; }

        //Core Stats
        public double Wins { get; set; }
        public double Losses { get; set; }
        public double Games { get; set; }

        //Computed Stats
        public double? WinPercentage { get; set; }
        public double? AvgPointDiff { get; set; }
        public double? Rating { get; set; }

        public void CalculateStats()
        {
            WinPercentage = (Wins / Games);
        }

        public Stats()
        {
            Wins = 10;
            Losses = 5;
            Games = 15;
        }
    }
}
