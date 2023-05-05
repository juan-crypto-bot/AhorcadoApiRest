using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest{
    public class HangedDbContext : DbContext{
        public DbSet<Hanged> Hanged {get; set; }
        //public DbSet<HangedLetter> HangedLetter {get; set; }
        //public DbSet<WordLetter> WordLetter {get; set; }
        public DbSet<Hang> Hang {get; set; }
        //public DbSet<Letter> Letter {get; set; }
        public DbSet<Player> PLayer {get; set; }
        public DbSet<Word> Word {get; set; }
        public HangedDbContext(DbContextOptions<HangedDbContext> options) : base(options){
            
        }
    }
}