using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "DamageUpgradeConfig", menuName = "Configs/Upgrades/DamageUpgradeConfig", order = 59)]
    public class DamageUpgradeConfig : UpgradeConfig
    {
        public DamageUpgradeTable DamageTable;
    }
}