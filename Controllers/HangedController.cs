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


        //Todos los create -------------------------------------------------------------------------------------------

        [HttpPost("{NewHanged}")]
        public IActionResult NewHanged([FromBody] string user)
        {
            return Ok(_hangedService.CreateHanged(user));
        }

        [HttpPost("{NewPlayer}")]
        public IActionResult CreatePlayer([FromBody] string name, string pass)
        {
            return Ok(_hangedService.CreatePlayer(name, pass));
        }

        [HttpPost("{newWord}")]
        public IActionResult CreateWord([FromBody] string meaning)
        {
            return Ok(_hangedService.CreateWord(meaning));
        }

        [HttpPost("{newLetter}")]
        public IActionResult CreateLetter([FromBody] string letter)
        {
            return Ok(_hangedService.CreateLetter(letter));
        }


        //Todos los read -------------------------------------------------------------------------------------------

        [HttpGet("{GetPlayer}")]
        public IActionResult GetPlayer([FromBody] string user)
        {
            return Ok(_hangedService.ReadPlayer(user));
        }

        [HttpGet("{GetWord}")]
        public IActionResult GetWord([FromBody] string meaning)
        {
            return Ok(_hangedService.ReadWord(meaning));
        }

        [HttpGet("{GetLetter}")]
        public IActionResult GetLetter([FromBody] string letter)
        {
            return Ok(_hangedService.ReadLetter(letter));
        }

        [HttpGet("{GetHanged}")]
        public IActionResult GetHanged([FromBody] int id)
        {
            return Ok(_hangedService.ReadHanged(id));
        }
        

        //Todos los delete

        [HttpDelete("{DeleteHanged}")]
        public void DeleteHanged([FromBody] int id)
        {
            _hangedService.DeleteHanged(id);
        }


        [HttpDelete("{DeletePlayer}")]
        public void DeletePlayer([FromBody] string user, string pass)
        {
            _hangedService.DeletePlayer(user, pass);
        }


        [HttpDelete("{DeleteWord}")]
        public void DeleteWord([FromBody] string meaning)
        {
            _hangedService.DeleteWord(meaning);
        }


        [HttpDelete("{DeleteLetter}")]
        public void DeleteLetter([FromBody] string letter)
        {
            _hangedService.DeleteLetter(letter);
        }


        //Todos los GetAll

        [HttpGet("{GetAllHanged}")]

        public IEnumerable<Hanged> GetAllHanged()
        {
            return _hangedService.GetAllHangeds();
        }

        [HttpGet("{GetAllPlayers}")]

        public IEnumerable<Player> GetAllPlayers()
        {
            return _hangedService.GetAllPlayers();
        }

        [HttpGet("{GetAllWords}")]

        public IEnumerable<Word> GetAllWords()
        {
            return _hangedService.GetAllWords();
        }

        [HttpGet("{GetAllLetters}")]

        public IEnumerable<Letter> GetAllLetters()
        {
            return _hangedService.GetAllLetters();
        }

        //-------------------------------------------------------------------------------------


        [HttpPost("{try}")]
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
}