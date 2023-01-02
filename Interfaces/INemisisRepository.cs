namespace SuperHeroApi.Interfaces
{
    public interface INemisisRepository
    {
        ICollection<Nemisis> GetNemeses();
        Nemisis GetNemisis(int nemisisId);
        bool CreateNemisis(Nemisis nemisis);
        bool UpdateNemisis(Nemisis nemisis);
        bool DeleteNemisis(Nemisis nemisis);
        bool Save();
        bool NemisisExists(int nemisisId);
    }
}
