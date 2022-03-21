using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeagueAPI.Model
{

    public enum Position
    {
        Goalkeeper = 1,
        Defender = 2,
        Midfielder = 3,
        Attacker = 4
    }

    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public Position Position { get; set; }

        [Range(14,77)]
        public int Age { get; set; }

        public string Nationality { get; set; }

        public Team Team { get; set; }
    }
}
