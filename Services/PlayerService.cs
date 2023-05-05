using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest{
    public interface IPlayerService{
        Player FindPlayerById(int id);

    }
    public class PlayerService : IPlayerService{

        private readonly ILogger<PlayerService> _logger;

        private readonly HangedDbContext _db;
        public PlayerService(ILogger<PlayerService> logger, HangedDbContext db){
            _db = db;
            _logger = logger;
            //_db.Database.EnsureCreated();    
        }

        public Player FindPlayerById(int id)
        {
            _logger.LogInformation("Searching for Player with id: " + id);
            var player = _db.PLayer.SingleOrDefault(p => p.Id == id);
            return player;
        }
    }
}
