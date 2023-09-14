namespace Throwing_Boxes
{
    public interface IHeroUpgradesManager
    {
        bool CanLevelUp(IHeroUpgrade upgrade);

        void LevelUp(IHeroUpgrade upgrade);

        IHeroUpgrade GetUpgrade(string id);

        IHeroUpgrade[] GetAllUpgrades();
    }
}