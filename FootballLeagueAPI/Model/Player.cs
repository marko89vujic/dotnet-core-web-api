using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public string Name { get; set; }

        public string LastName { get; set; }

        public Position Position { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }
    }
}
