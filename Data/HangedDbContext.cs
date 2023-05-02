using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest{
    public class HangDbContext : DbContext{
        public DbSet<Hang> Hang {get; set; }
        public HangDbContext(DbContextOptions<HangDbContext> options) : base(options){
            
        }
    }
}