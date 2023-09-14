using System;

namespace Throwing_Boxes
{
    [Serializable]
    public struct DamageUpgradeTable
    {
        public float GetDamage(int level) =>
            StartDamage + UpgradeDamage * level;

        public float NextDifferenceDamage(int level, int maxLevel)
        {
            if (level != maxLevel)
                return UpgradeDamage;

            return 0;
        }
        
        public float StartDamage;
        public float UpgradeDamage;
    }
}