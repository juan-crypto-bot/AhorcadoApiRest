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
        //private readonly ILogger<BeersController> _logger;
        private readonly IHangedService _hangedService;
        private readonly IPlayerService _playerService;

        //private readonly BeersConfig _config;
        public HangedController(IHangedService hangedService, IPlayerService playerService){
            //_logger = logger;
            _hangedService = hangedService;
            _playerService = playerService;
            //_config = bc.Value;
        }
 
        [HttpGet]
        public IEnumerable<Hanged> Get()
        {
            return _hangedService.GetAll();
        }
        
        [HttpGet("{id:int}")]
    
        public Hanged GetForecast(int id){
            return _hangedService.GetStatus(id);
        } 

        /*[HttpPost("{id:int}")]

        public void NewGame(int id){
            Player player = _playerService.FindPlayerById(id);
            _hangedService.NewGame(player);
        }*/
     
    }
}