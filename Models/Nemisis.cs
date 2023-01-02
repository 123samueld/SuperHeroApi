namespace SuperHeroApi.Models
{
    public class Nemisis
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Crimes { get; set; } = null!;
        public Person Person { get; set; } = null!;
    }
}
