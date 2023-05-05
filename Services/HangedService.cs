using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest{
    public interface IHangedService{
        
        Hanged GetStatus(int id);
        Hanged FindById(int id);
        IEnumerable<Hanged> GetAll();
        //void NewGame(Player player);

        //IActionResult Try(int id, char letra);
        //IEnumerable<Beer> GetAll();
        //Beer FindById(int id);

        //bool TryAdd(Beer beer);
        //IEnumerable<Beer> FindByName(string name);
    }
    public class HangedService : IHangedService{

        private readonly ILogger<HangedService> _logger;

        private readonly HangedDbContext _db;
        public HangedService(ILogger<HangedService> logger, HangedDbContext db){
            _db = db;
            _logger = logger;
            _db.Database.EnsureCreated();    
        }

        public Hanged GetStatus(int id){
           return this.FindById(id);
        } 

        public Hanged FindById(int id)
        {
            _logger.LogInformation("Searching for Hang with id: " + id);
            var hang = _db.Hanged.SingleOrDefault(h => h.Id == id);
            return hang;
        }

        public IEnumerable<Hanged> GetAll()
        {
            return _db.Hanged.ToList();
        }

        /*public void NewGame(Player player){
            var game = new Hanged(player);
        }*/

       /* public IActionResult Try(int id, char letra){
            var hanged = _db.Hanged.SingleOrDefault(h => h.Id == id);
            if(hanged != null){
            hanged.TryAtempt(letra);
             _db.SaveChanges();
        }*/
    }
}   