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
        int PlayerId { get; set; }
        int FirebaseId { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }

        DateTime Birthday { get; set; }
        bool LeftHanded { get; set; }

        string Cohort { get; set; }
    }
}
