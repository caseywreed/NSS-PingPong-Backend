using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSS_Ping_Pong_Backend.Models
{
    public class Player
    {
        [Key]
        // Will be the same as the Firebase uid that comes back after login
        public int PlayerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool LeftHanded { get; set; }
        public string Cohort { get; set; }

        public Stats Stats { get; set; }
    }
}
