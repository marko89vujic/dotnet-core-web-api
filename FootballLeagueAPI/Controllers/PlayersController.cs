using System.Threading.Tasks;
using FootballLeagueAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var players = await _playersService.GetAllPlayersAsync();
                return Ok(players);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
            
        }
    }
}
