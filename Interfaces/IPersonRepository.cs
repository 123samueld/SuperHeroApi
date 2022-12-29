namespace SuperHeroApi.Interfaces
{
    public interface IPersonRepository
    {
        ICollection<Person> GetPeople();
        Person GetPerson(int personId);
        bool PersonExists(int personId);
    }
}
