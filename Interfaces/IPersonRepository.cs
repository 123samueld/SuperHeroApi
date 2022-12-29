namespace SuperHeroApi.Interfaces
{
    public interface IPersonRepository
    {
        ICollection<Person> GetPeople();
        Person GetPerson(int personId);
        bool CreatePerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        bool Save();
        bool PersonExists(int personId);
    }
}
