namespace SuperHeroApi.Repository
{
    public class PowerRepository : IPowerRepository
    {
        private readonly DataContext _context;

        public PowerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Power> GetPowers()
        {
            return _context.Powers.ToList();
        }

        public Power GetPower(int powerId)
        {
            return _context.Powers
                .Where(p => p.Id == powerId)
                .FirstOrDefault();
        }

        public bool PowerExists(int powerId)
        {
            return _context.Powers.Any(p => p.Id == powerId);
        }
    }
}
