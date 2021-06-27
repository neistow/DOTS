using System.Threading.Tasks;
using DOTS.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOTS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return Ok(await _playerService.GetAllPlayers());
        }
    }
}