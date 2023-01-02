namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
            
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<Nemisis> Nemeses { get; set;}
        public DbSet<Person_Power> People_Powers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person_Power>()
                .HasKey(sh => new { sh.PersonId, sh.PowerId });
            modelBuilder.Entity<Person_Power>()
                .HasOne(p => p.Person)
                .WithMany(sh => sh.People_Powers)
                .HasForeignKey(p => p.PersonId);
            modelBuilder.Entity<Person_Power>()
                .HasOne(pw => pw.Power)
                .WithMany(sh => sh.People_Powers)
                .HasForeignKey(pw => pw.PowerId);
        }
    }
}
