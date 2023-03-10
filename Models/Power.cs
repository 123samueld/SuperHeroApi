namespace SuperHeroApi.Models
{
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Level { get; set; }
        public ICollection<Person_Power> People_Powers { get; set; } = null!;
    }
}
