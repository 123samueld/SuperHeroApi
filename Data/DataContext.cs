namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
            
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Disguise> Disguises { get; set;}
        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>()
                .HasKey(sh => new { sh.PersonId, sh.PowerId });
            modelBuilder.Entity<SuperHero>()
                .HasOne(p => p.Person)
                .WithMany(sh => sh.SuperHeroes)
                .HasForeignKey(p => p.PersonId);
            modelBuilder.Entity<SuperHero>()
                .HasOne(pw => pw.Power)
                .WithMany(sh => sh.SuperHeroes)
                .HasForeignKey(pw => pw.PowerId);
        }
    }
}
