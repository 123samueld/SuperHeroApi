namespace SuperHeroApi.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int NemisisId { get; set; }
        public ICollection<Nemisis> Nemeses { get; set; } = null!;
        public ICollection<Person_Power> People_Powers { get; set; } = null!;

    }
}
