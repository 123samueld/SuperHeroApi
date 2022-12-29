namespace SuperHeroApi.Interfaces
{
    public interface IDisguiseRepository
    {
        ICollection<Disguise> GetDisguises();
        Disguise GetDisguise(int disguiseId);
        bool CreateDisguise(Disguise disguise);
        bool UpdateDisguise(Disguise disguise);
        bool DeleteDisguise(Disguise disguise);
        bool Save();        
        bool DisguiseExists(int disguiseId);
        
    }
}
