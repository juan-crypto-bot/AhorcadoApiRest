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
            modelBuilder.Entity<Player>().HasIndex(p => p.Username).IsUnique();
            modelBuilder.Entity<Word>().HasIndex(w => w.Meaning).IsUnique();

            //modelBuilder.Entity<Hanged>().HasOne(h => h.Player).WithOne(p => p.Hanged).HasForeignKey<Hanged>(h => h.PlayerId);
            //modelBuilder.Entity<Hanged>().HasOne(h => h.Word).WithOne(w => w.Hanged).HasForeignKey<Hanged>(h => h.WordId);
            //modelBuilder.Entity<Hanged>().HasMany(h => h.UsedLetter).WithOne();
            //modelBuilder.Entity<Word>().HasMany(w => w.Letters).WithOne();
        }
        public HangedDbContext(DbContextOptions<HangedDbContext> options) : base(options)
        {

        }
    }
}