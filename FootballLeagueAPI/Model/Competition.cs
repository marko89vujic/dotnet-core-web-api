using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeagueAPI.Model
{
    public enum CompetitionType
    {
        NationalLeague = 1,
        ChampionsLeague = 2,
        EuropaLeague = 3,
        NationalCup = 4
    }
    public class Competition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CompetitionType CompetitionType;

        public List<Team> Teams { get; set; }
    }
}
