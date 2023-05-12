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
        }
        public HangedDbContext(DbContextOptions<HangedDbContext> options) : base(options)
        {

        }
    }
}