namespace SuperHeroApi.Repository
{
    public class DisguiseRepository : IDisguiseRepository
    {
        private readonly DataContext _context;

        public DisguiseRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Disguise> GetDisguises()
        {
            return _context.Disguises.ToList();
        }

        public Disguise GetDisguise(int disguiseId)
        {
            return _context.Disguises
                .Where(d => d.Id == disguiseId)
                .FirstOrDefault();
        }

        public bool DisguiseExists(int disguiseId)
        {
            return _context.Disguises.Any(d => d.Id == disguiseId);
        }

        public bool CreateDisguise(Disguise disguise)
        {
            _context.Add(disguise);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDisguise(Disguise disguise)
        {

            _context.Update(disguise);
            return Save();
        }

        public bool DeleteDisguise(Disguise disguise)
        {

            _context.Remove(disguise);
            return Save();
        }
    }
}
