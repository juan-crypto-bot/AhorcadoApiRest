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

    public class WordController : ControllerBase
    {
        private readonly ILogger<WordController> _logger;
        private readonly IWordService _wordService;

        public WordController(IWordService wordService, ILogger<WordController> logger)
        {
            _logger = logger;
            _wordService = wordService;
        }

        [HttpPost("newWord")]
        public IActionResult CreateWord([FromBody] WordDTO wordDTO)
        {
            return Ok(_wordService.CreateWord(wordDTO));
        }

        [HttpGet("GetWord")]
        public IActionResult GetWord([FromBody] WordDTO wordDTO)
        {
            return Ok(_wordService.ReadWord(wordDTO));
        }

        [HttpPost("UpdateWord")]
        public IActionResult UpdateWord([FromBody] WordDTO wordDTO)
        {
            return Ok(_wordService.UpdateWord(wordDTO));
        }

        [HttpDelete("DeleteWord")]
        public void DeleteWord([FromBody] WordDTO wordDTO)
        {
            _wordService.DeleteWord(wordDTO);
        }

        [HttpGet("GetAllWords")]

        public IEnumerable<Word> GetAllWords()
        {
            return _wordService.GetAllWords();
        }
    }
}

