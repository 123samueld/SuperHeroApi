namespace SuperHeroApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Disguise>? Disguises { get; set; }
        public ICollection<SuperHero>? SuperHeroes { get; set; }

    }
}
