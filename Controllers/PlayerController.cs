using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace AhorcadoApiRest
{

    [ApiController]
    [Route("[controller]")]

    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
        {
            _logger = logger;
            _playerService = playerService;
        }

        [HttpPost("NewPlayer")]
        public IActionResult CreatePlayer([FromBody] PlayerDTO playerDTO)
        {
            return Ok(_playerService.CreatePlayer(playerDTO));
        }

        [HttpGet("GetPlayer")]
        public IActionResult GetPlayer([FromBody] PlayerDTO playerDTO)
        {
            return Ok(_playerService.ReadPlayer(playerDTO));
        }

        [HttpPost("UpdatePlayer")]
        public IActionResult UpdatePlayer([FromBody] JObject data)
        {
            PlayerDTO playerDTO = data["playerDTO"].ToObject<PlayerDTO>();
            var newPass = data["newPass"].ToString();
            return Ok(_playerService.UpdatePlayer(playerDTO, newPass));
        }

        [HttpDelete("DeletePlayer")]
        public void DeletePlayer([FromBody] PlayerDTO playerDTO)
        {
            _playerService.DeletePlayer(playerDTO);
        }

        [HttpGet("GetAllPlayers")]

        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerService.GetAllPlayers();
        }
    }
}