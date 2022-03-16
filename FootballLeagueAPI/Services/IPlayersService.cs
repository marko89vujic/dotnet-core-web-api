using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeagueAPI.Model;

namespace FootballLeagueAPI.Services
{
    public interface IPlayersService
    {
        Task<Player[]> GetAllPlayersAsync();

        void AddPlayer(Player player);

        void DeletePlayer(Player player);

        Player GetPlayerById(int playerId);
    }
}
