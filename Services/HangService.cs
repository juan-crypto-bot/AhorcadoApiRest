using System.Linq;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest{
    public interface IHangService{
        
        Hang GetStatus(int id);
        Hang FindById(int id);
        //IEnumerable<Beer> GetAll();
        //Beer FindById(int id);

        //bool TryAdd(Beer beer);
        //IEnumerable<Beer> FindByName(string name);
    }
    public class HangService : IHangService{

        private readonly ILogger<HangService> _logger;

        private readonly HangDbContext _db;
        public HangService(ILogger<HangService> logger, HangDbContext db){
            _db = db;
            _logger = logger;
            _db.Database.EnsureCreated();    
        }

        public Hang GetStatus(int id){
           return this.FindById(id);
        } 

        public Hang FindById(int id)
        {
            _logger.LogInformation("Searching for beer with id: " + id);
            var hang = _db.Hang.SingleOrDefault(h => h.Id == id);
            return hang;
        }
    }
}   