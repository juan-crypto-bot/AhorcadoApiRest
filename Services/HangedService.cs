using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest{
    public interface IHangedService{
        Hanged FindById(int id);
        IEnumerable<Hanged> GetAll();

        void NewGame(Player player, Word word);

    }
    public class HangedService : IHangedService{

        private readonly ILogger<HangedService> _logger;

        private readonly HangedDbContext _db;
        public HangedService(ILogger<HangedService> logger, HangedDbContext db){
            _db = db;
            _logger = logger;
            _db.Database.EnsureCreated();    
        }

        public Hanged FindById(int id)
        {
            _logger.LogInformation("Searching for Hang with id: " + id);
            Hanged hang = _db.Hanged.Include("Player.Hang.Word").SingleOrDefault(h => h.Id == id);
            return hang;
        }

        public IEnumerable<Hanged> GetAll()
        {
            return _db.Hanged.ToList();
        }

        public bool TryAdd(Hanged hanged){
            //beer.Id=1;
            _db.Hanged.Add(hanged);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id){
            var hanged = _db.Hanged.SingleOrDefault(h => h.Id == id);
            if(hanged !=null){
                _db.Hanged.Remove(hanged);
                _db.SaveChanges();
                return true;
            }
            return false; 
        }

        public void NewGame(Player player, Word word){
            var hanged = new Hanged(player, word);
            _db.Hanged.Add(hanged);
            _db.SaveChanges();
        }
    }
}   