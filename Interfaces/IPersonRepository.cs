namespace SuperHeroApi.Interfaces
{
    public interface IPersonRepository
    {
        ICollection<Person> GetPeople();
        Person GetPerson(int personId);
        ICollection<Nemisis> GetTheNemesesOfAPerson(int personId);
        bool CreatePerson(int powerId, Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        bool Save();
        bool PersonExists(int personId);
    }
}
