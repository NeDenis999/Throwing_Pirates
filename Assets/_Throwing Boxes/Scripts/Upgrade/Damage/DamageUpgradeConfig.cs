using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "DamageUpgradeConfig", menuName = "Configs/DamageUpgradeConfig", order = 58)]
    public class DamageUpgradeConfig : UpgradeConfig
    {
        public DamageUpgradeTable DamageTable;
    }
}