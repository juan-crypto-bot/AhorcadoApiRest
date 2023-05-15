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

        public HangedController(IHangedService hangedService, ILogger<HangedController> logger)
        {
            _logger = logger;
            _hangedService = hangedService;
        }


        [HttpPost("NewHanged")]
        public IActionResult NewHanged([FromBody] PlayerDTO playerDTO)
        {
            return Ok(_hangedService.CreateHanged(playerDTO));
        }


        [HttpGet("GetHanged")]
        public IActionResult GetHanged([FromBody] int id)
        {
            return Ok(_hangedService.ReadHanged(id));
        }


        [HttpDelete("DeleteHanged")]
        public void DeleteHanged([FromBody] int id)
        {
            _hangedService.DeleteHanged(id);
        }


        [HttpGet("GetAllHanged")]

        public IEnumerable<Hanged> GetAllHanged()
        {
            return _hangedService.GetAllHangeds();
        }


        /* [HttpPost("TryLetter")]
         public bool Play([FromBody] int HangedId, string letter)
         {
             char firstChar = letter.FirstOrDefault();
             var a = _hangedService.Play(HangedId, firstChar);
             if (a) Console.WriteLine("true");
             return a;
             /*try
             {
                 Ok(_hangedService.Play(HangedId, letter));
             }
             catch
             {
                 return BadRequest("An error had ocurred");
             }*/
    }
}
