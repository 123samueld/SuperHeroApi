namespace SuperHeroApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePerson(Person person)
        {
            _context.Add(person);
            return Save();
        }

        public bool DeletePerson(Person person)
        {
            _context.Remove(person);
            return Save();
        }

        public ICollection<Person> GetPeople()
        {
            return _context.People.ToList();
        }

        public Person GetPerson(int personId)
        {
            return _context.People
                .Where(p => p.Id == personId)
                .FirstOrDefault();
        }

        public bool PersonExists(int personId)
        {
            return _context.People.Any(p => p.Id == personId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePerson(Person person)
        {
            _context.Update(person);
            return Save();
        }
    }
}
