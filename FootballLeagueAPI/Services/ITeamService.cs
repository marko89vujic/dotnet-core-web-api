using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeagueAPI.Model;

namespace FootballLeagueAPI.Services
{
    public interface ITeamService
    {
        List<Team> GetAllTeams();

        void CreateTeam();

        void DeleteTeam(Team team);

        Team GetTeamById(int teamId);
    }
}
