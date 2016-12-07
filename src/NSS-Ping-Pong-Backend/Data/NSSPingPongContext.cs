using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NSS_Ping_Pong_Backend.Models;

namespace NSS_Ping_Pong_Backend.Data
{
    public class NSSPingPongContext : DbContext
    {
        public NSSPingPongContext(DbContextOptions<NSSPingPongContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GamePlayer> GamePlayer { get; set; }
        public DbSet<Stats> Stats { get; set; }
    }
}
