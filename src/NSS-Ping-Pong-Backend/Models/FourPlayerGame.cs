using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSS_Ping_Pong_Backend.Models
{
    public class FourPlayerGame
    {
        public Player playerOne { get; set; }
        public Player playerTwo { get; set; }
        public Player playerThree { get; set; }
        public Player playerFour { get; set; }
        public double teamOneScore { get; set; }
        public double teamTwoScore { get; set; }
    }
}
