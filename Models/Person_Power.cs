namespace SuperHeroApi.Models
{
    public class Person_Power
    {
        
        public int Id { get; set; }

        //public string? SuperHeroName { get; set; }
        public int PersonId { get; set; }
        public int PowerId { get; set; }
        public Person Person { get; set; } = null!;
        public Power Power { get; set; } = null!;
    }
}
