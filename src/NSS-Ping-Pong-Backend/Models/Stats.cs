using System;
using System.ComponentModel.DataAnnotations;

namespace NSS_Ping_Pong_Backend.Models
{
    public class Stats
    {
        [Key]
        public int StatsId { get; set; }
        public int PlayerId { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
        public int? WinPercentage { get; set; }
        public int? AvgPointDiff { get; set; }
        public int? Rating { get; set; }

        public void CalculateStats()
        {
            throw new NotImplementedException();
        }
    }
}
