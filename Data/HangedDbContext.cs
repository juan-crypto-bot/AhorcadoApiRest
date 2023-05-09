using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest{
    public class HangedDbContext : DbContext{
        public DbSet<Hanged> Hanged {get; set; }
        //public DbSet<HangedLetter> HangedLetter {get; set; }
        //public DbSet<WordLetter> WordLetter {get; set; }
        public DbSet<Hang> Hang {get; set; }
        public DbSet<Letter> Letter {get; set; }
        public DbSet<Player> PLayer {get; set; }
        public DbSet<Word> Word {get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WordLetter>().HasKey(wl => new { wl.LetterId, wl.WordId });
        modelBuilder.Entity<HangedLetter>().HasKey(wl => new { wl.LetterId, wl.HangedId });
    }
        public HangedDbContext(DbContextOptions<HangedDbContext> options) : base(options){
            
        }
    }
}