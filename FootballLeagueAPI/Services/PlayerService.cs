using FootballLeagueAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeagueAPI.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueAPI.Services
{
    public class PlayerService : IPlayersService
    {
        private LeagueContext _leagueContext;

        public PlayerService(LeagueContext leagueContext)
        {
            _leagueContext = leagueContext;
        }
        public void AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public async Task<Player[]> GetAllPlayersAsync()
        {
            var players = await _leagueContext.Players.ToArrayAsync();
            return players;
        }

        public Player GetPlayerById(int playerId)
        {
            throw new NotImplementedException();
        }
    }
}
