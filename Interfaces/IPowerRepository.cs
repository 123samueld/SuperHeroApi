namespace SuperHeroApi.Interfaces
{
    public interface IPowerRepository
    {
        ICollection<Power> GetPowers();
        Power GetPower(int powerId);
        bool PowerExists(int powerId);
    }
}
