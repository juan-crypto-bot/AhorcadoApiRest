using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest
{
    public class HangedDbContext : DbContext
    {
        public DbSet<Hanged> Hanged { get; set; }
        public DbSet<Letter> Letter { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Word> Word { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Letter>().HasIndex(l => l.Value).IsUnique();
            modelBuilder.Entity<Player>().HasIndex(p => p.Username).IsUnique();
            modelBuilder.Entity<Word>().HasIndex(w => w.Meaning).IsUnique();
            
            // modelBuilder.Entity<Word>().HasMany(w => w.Letters);
        }
        public HangedDbContext(DbContextOptions<HangedDbContext> options) : base(options)
        {

        }
    }
}