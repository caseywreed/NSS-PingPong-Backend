using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSS_Ping_Pong_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSS_Ping_Pong_Backend.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NSSPingPongContext(serviceProvider.GetRequiredService<DbContextOptions<NSSPingPongContext>>()))
            {
                // Look for any players
                if (context.Player.Any())
                {
                    return;   // DB has been seeded
                }
                //   Player
                //var players = new Player[]
                //{
                //  new Player {
                //      FirstName = "Casey",
                //      LastName = "Reed",
                //      LeftHanded = false,
                //      Cohort = "15"
                //  },
                //  new Player {
                //      FirstName = "Fletcher",
                //      LastName = "Watson",
                //      LeftHanded = false,
                //      Cohort = "15"
                //  },
                //  new Player {
                //      FirstName = "Delaine",
                //      LastName = "Wendling",
                //      LeftHanded = true,
                //      Cohort = "14"
                //  },
                //  new Player {
                //      FirstName = "Matt",
                //      LastName = "Hamil",
                //      LeftHanded = false,
                //      Cohort = "13"
                //  },
                //  new Player {
                //      FirstName = "Grant",
                //      LastName = "Regnier",
                //      LeftHanded = true,
                //      Cohort = "15"
                //  },
                //  new Player {
                //      FirstName = "Edgar",
                //      LastName = "Barajas",
                //      LeftHanded = false,
                //      Cohort = "16"
                //  },
                //  new Player {
                //      FirstName = "Megan",
                //      LastName = "Ducharme",
                //      LeftHanded = false,
                //      Cohort = "13"
                //  },
                //  new Player {
                //      FirstName = "Zack",
                //      LastName = "Repass",
                //      LeftHanded = true,
                //      Cohort = "15"
                //  },
                //  new Player {
                //      FirstName = "Joe",
                //      LastName = "Shepherd",
                //      LeftHanded = false,
                //      Cohort = "0"
                //  },
                //  new Player {
                //      FirstName = "Steve",
                //      LastName = "Brownlee",
                //      LeftHanded = true,
                //      Cohort = "0"
                //  }
                //};
                //foreach (Player p in players)
                //{
                //    context.Player.Add(p);
                //}
                //context.SaveChanges();

                // GamePlayer Seeding
                // Uncomment to seed each player with a randomly generated GamePlayer
                //GamePlayer gp = null;
                //var rnd = new Random();
                //foreach (Player p in players)
                //{
                //    int num = rnd.Next(1, 3);
                //    gp = new GamePlayer(p, num);
                //    context.GamePlayer.Add(gp);
                //}
                //context.SaveChanges();
            }
        }
    }
}
