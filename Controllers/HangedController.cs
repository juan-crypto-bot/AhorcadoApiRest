using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AhorcadoApiRest{

    [ApiController]
    [Route("[controller]")]
    
    public class HangedController : ControllerBase{
        private readonly ILogger<HangedController> _logger;
        private readonly IHangedService _hangedService;
        private readonly IPlayerService _playerService;
        private readonly IWordService _wordService;

        //private readonly BeersConfig _config;
        public HangedController(IHangedService hangedService, IPlayerService playerService, IWordService wordService, ILogger<HangedController> logger){
            _logger = logger;
            _hangedService = hangedService;
            _playerService = playerService;
            _wordService = wordService;
            //_config = bc.Value;
        }
 
        [HttpGet]
        public IEnumerable<Hanged> Get()
        {
            return _hangedService.GetAll();
        }
        
        [HttpGet("{id:int}")]
    
        public Hanged GetForecast(int id){
            return _hangedService.FindById(id);
        }

        [HttpPost("{PlayerId:int}")]
        public void NewGame(int PlayerId){
            var player = _playerService.FindPlayerById(PlayerId);
            if(player!=null){
                var word = _wordService.SelectRandomWord();
                _hangedService.NewGame(player, word);
            }
            else _logger.LogInformation("Id provided not exist");
        } 

        [HttpPost("{HangedId:int}/try/{letter:char}")]
        public void Play(int HangedId, char letter){
            var hanged = _hangedService.FindById(HangedId);
            if(hanged!=null){
                hanged.
                
                _hangedService.TryLetter(letter);
            }
            else _logger.LogInformation("Id provided not exist");
        } 
     
    }
}