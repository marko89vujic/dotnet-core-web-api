using System;
using System.Linq;
using System.Threading.Tasks;
using FootballLeagueAPI.DataContext;
using FootballLeagueAPI.Model;
using FootballLeagueAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FootballLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private IPlayersService _playersService;

        public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;
        }

        #region GET

        [HttpGet]
        public async Task<ActionResult<Player[]>> Get()
        {
            try
            {
                return await _playersService.GetAllPlayersAsync();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }

        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Player>> Get(string name)
        {
            try
            {
                var player = await _playersService.GetAsyncPlayerByName(name);

                if (player == null)
                {
                    return NotFound($"Not found player with specific name {name}");
                }

                return player;
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
        }

        [HttpGet("{playerId:int}")]
        public async Task<ActionResult<Player>> Get(int playerId)
        {
            try
            {
                var player = await _playersService.GetAsyncPlayerById(playerId);

                if (player == null)
                {
                    return NotFound($"Not found player with specific id {playerId}");
                }

                return player;
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Player[]>> Search(string lastName)
        {
            try
            {
                var players = await _playersService.SearchByLastNameAsync(lastName);

                if (players == null)
                {
                    return NotFound($"Not found players with with start last name  {lastName}");
                }

                return players;
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<ActionResult<Player>> Post(Player player)
        {
            try
            {
                
                _playersService.AddPlayer(player);

                if (await _playersService.SaveChangesAsync())
                {
                    return Created("",player);
                }

                return BadRequest();
                
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
        }

        #endregion

        #region PUT

        [HttpPut("{name}")]
        public async Task<ActionResult<Player>> Put(string name, Player player)
        {
            try
            {
                var oldPlayer = await _playersService.GetAsyncPlayerByName(player.Name);

                if (oldPlayer == null)
                {
                    return NotFound($"Colud not found player with name {name}");
                }

                oldPlayer.Name = name;

                if (await _playersService.SaveChangesAsync())
                {
                    return oldPlayer;
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{lastName}")]
        public async Task<IActionResult> Delete(string lastName)
        {
            try
            {
                var allPlayers = await _playersService.GetAllPlayersAsync();

                var playerForDelete = allPlayers.FirstOrDefault(x => x.LastName == lastName);

                if (playerForDelete == null)
                {
                    return NotFound($"Colud not found player with lastname {lastName}");
                }

                _playersService.DeletePlayer(playerForDelete);

                if (await _playersService.SaveChangesAsync())
                {
                    return Ok();
                }

                return BadRequest();

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure!!");
            }
        }

        #endregion
    }
}
