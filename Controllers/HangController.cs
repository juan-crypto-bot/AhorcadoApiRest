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
    
    public class HangController : ControllerBase{
        //private readonly ILogger<BeersController> _logger;
        private readonly IHangService _hangedService;

        //private readonly BeersConfig _config;
        public HangController(IHangService hangedService){
            //_logger = logger;
            _hangedService = hangedService;
            //_config = bc.Value;
        }

        [HttpGet("{id:int}")]
    
        public Hang status(int id){
            return _hangedService.GetStatus(id);
        } 

        /*[HttpGet("/word")]

        public Word getHiddenWord(){
            return _
        }*/
        
    }
}