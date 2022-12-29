namespace SuperHeroApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
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
    }
}
