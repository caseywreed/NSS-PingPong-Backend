using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSS_Ping_Pong_Backend.Models
{
    public class GamePlayer
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public int TeamId { get; set; }
    }
}
