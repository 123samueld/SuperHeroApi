namespace SuperHeroApi.Interfaces
{
    public interface IDisguiseRepository
    {
        ICollection<Disguise> GetDisguises();
        Disguise GetDisguise(int disguiseId); 
        bool DisguiseExists(int disguiseId);
    }
}
