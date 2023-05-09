using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AhorcadoApiRest
{

    [ApiController]
    [Route("[controller]")]

    public class HangedController : ControllerBase
    {
        private readonly ILogger<HangedController> _logger;
        private readonly IHangedService _hangedService;
        //private readonly BeersConfig _config;
        public HangedController(IHangedService hangedService, ILogger<HangedController> logger)
        {
            _logger = logger;
            _hangedService = hangedService;
            //_config = bc.Value;
        }

        [HttpGet]
        public IEnumerable<Hanged> Get()
        {
            return _hangedService.GetAll();
        }

        [HttpGet("{id:int}")]

        public Hanged GetForecast(int id)
        {
            return _hangedService.FindById(id);
        }

        [HttpPost("play/{PlayerId:int}")]
        public IActionResult NewGame(int PlayerId)
        {
            try
            {
                return Ok(_hangedService.NewGame(PlayerId));
            }
            catch
            {
                return BadRequest("An error had ocurred when the Hanged try to create");
            }
        }

        [HttpPost("{newWord}")]
        public IActionResult CreateWord([FromBody] string param)
        {
            try
            {
                return Ok(_hangedService.CreateWord(param));
            }
            catch
            {
                return BadRequest("An error had ocurred when the Word try to create");
            }
        }

        [HttpPost("{try}")]
        public IActionResult Play([FromBody] int HangedId, char letter)
        {
            try
            {
                Ok(_hangedService.Play(HangedId, letter));
            }
            catch
            {
                return BadRequest("An error had ocurred");
            }
        }
    }
}