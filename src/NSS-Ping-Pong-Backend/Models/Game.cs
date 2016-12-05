using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSS_Ping_Pong_Backend.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public DateTime DatePlayed { get; set; }
        public ICollection<GamePlayer> GamePlayers { get; set; }
        public int TeamOneScore { get; set; }
        public int TeamTwoScore { get; set; }
    }
}
