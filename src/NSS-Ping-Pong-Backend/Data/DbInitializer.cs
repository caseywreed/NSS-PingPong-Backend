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
                var players = new Player[]
                {
                  new Player {
                      FirstName = "Casey",
                      LastName = "Reed",
                      LeftHanded = false,
                      Cohort = "15"
                  },
                  new Player {
                      FirstName = "Fletcher",
                      LastName = "Watson",
                      LeftHanded = false,
                      Cohort = "15"
                  },
                  new Player {
                      FirstName = "Delaine",
                      LastName = "Wendling",
                      LeftHanded = true,
                      Cohort = "14"
                  },
                  new Player {
                      FirstName = "Matt",
                      LastName = "Hamil",
                      LeftHanded = false,
                      Cohort = "13"
                  },
                  new Player {
                      FirstName = "Grant",
                      LastName = "Regnier",
                      LeftHanded = true,
                      Cohort = "15"
                  }
                };
                foreach (Player p in players)
                {
                    context.Player.Add(p);
                }
                context.SaveChanges();
            }
        }
    }
}
