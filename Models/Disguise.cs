namespace SuperHeroApi.Models
{
    public class Disguise
    {
        public int Id { get; set; }
        public string HeroName { get; set; } = null!;
        public  string Costume { get; set; } = null!;
        public Person? Person { get; set; }
    }
}
