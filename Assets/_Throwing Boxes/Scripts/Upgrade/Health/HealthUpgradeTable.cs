using System;

namespace Throwing_Boxes
{
    [Serializable]
    public struct HealthUpgradeTable
    {
        public float GetHealth(int level) =>
            StartHealth + UpgradeHealth * level;

        public float NextDifferenceHealth(int level, int maxLevel)
        {
            if (level != maxLevel)
                return UpgradeHealth;

            return 0;
        }
        
        public float StartHealth;
        public float UpgradeHealth;
    }
}