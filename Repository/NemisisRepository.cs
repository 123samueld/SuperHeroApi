namespace SuperHeroApi.Repository
{
    public class NemisisRepository : INemisisRepository
    {
        private readonly DataContext _context;

        public NemisisRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNemisis(Nemisis nemisis)
        {
            _context.Add(nemisis);
            return Save();

        }

        public bool DeleteNemisis(Nemisis nemisis)
        {
            _context.Remove(nemisis);
            return Save();
        }

        public ICollection<Nemisis> GetNemeses()
        {
            return _context.Nemeses.ToList();
        }

        public Nemisis GetNemisis(int nemisisId)
        {
            return _context.Nemeses
                .Where(n => n.Id == nemisisId)
                .FirstOrDefault();
        }

        public bool NemisisExists(int nemisisId)
        {
            return _context.Nemeses.Any(n => n.Id == nemisisId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateNemisis(Nemisis nemisis)
        {
            _context.Update(nemisis);
            return Save();
        }
    }
}
