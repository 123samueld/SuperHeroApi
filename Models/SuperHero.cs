namespace SuperHeroApi.Models
{
    public class SuperHero
    {
        public int PersonId { get; set; }
        public int PowerId { get; set; }
        public Person? Person { get; set; }
        public Power? Power { get; set; }
    }
}
