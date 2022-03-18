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
            if (player == null)
            {
                return;
            }

            _leagueContext.Players.Add(player);
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

        public async Task<Player> GetAsyncPlayerById(int playerId)
        {
            var player = await _leagueContext.Players.FirstOrDefaultAsync(x => x.Id == playerId);

            return player;
        }

        public async Task<Player> GetAsyncPlayerByName(string name)
        {
            var player = await _leagueContext.Players.FirstOrDefaultAsync(x => x.Name == name);

            return player;
        }

        public async Task<Player[]> SearchByLastNameAsync(string lastName)
        {
            var players = await _leagueContext.Players.Where(x => x.LastName.StartsWith(lastName)).ToArrayAsync();

            return players;
        }

        public async Task<bool> SaveChangesAsync()
        {
            //_logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _leagueContext.SaveChangesAsync()) > 0;
        }
    }
}
