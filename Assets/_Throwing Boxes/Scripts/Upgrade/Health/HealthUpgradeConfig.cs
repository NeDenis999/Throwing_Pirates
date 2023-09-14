using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "HealthUpgradeConfig", menuName = "Configs/HealthUpgradeConfig", order = 58)]
    public class HealthUpgradeConfig : UpgradeConfig
    {
        public HealthUpgradeTable HealthTable;
    }
}