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

    public class LetterController : ControllerBase
    {
        private readonly ILogger<LetterController> _logger;
        private readonly ILetterService _letterService;

        public LetterController(ILetterService letterService, ILogger<LetterController> logger)
        {
            _logger = logger;
            _letterService = letterService;
        }

        [HttpPost("newLetter")]
        public IActionResult CreateLetter([FromBody] LetterDTO letterDTO)
        {
            return Ok(_letterService.CreateLetter(letterDTO));
        }

        [HttpGet("GetLetter")]
        public IActionResult GetLetter([FromBody] LetterDTO letterDTO)
        {
            return Ok(_letterService.ReadLetter(letterDTO));
        }

        [HttpDelete("DeleteLetter")]
        public void DeleteLetter([FromBody] LetterDTO letterDTO)
        {
            _letterService.DeleteLetter(letterDTO);
        }

        [HttpGet("GetAllLetters")]

        public IEnumerable<Letter> GetAllLetters()
        {
            return _letterService.GetAllLetters();
        }
    }
}

