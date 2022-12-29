namespace SuperHeroApi.Interfaces
{
    public interface IPowerRepository
    {
        ICollection<Power> GetPowers();
        Power GetPower(int powerId);
        bool CreatePower(Power power);
        bool UpdatePower(Power power);
        bool DeletePower(Power power);
        bool Save();
        bool PowerExists(int powerId);
    }
}
