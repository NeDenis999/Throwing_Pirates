using System;
using UnityEngine;

namespace Throwing_Boxes
{
    [Serializable]
    public struct SpeedUpgradeTable
    {
        public float GetSpeed(int level, int maxLevel) =>
            Mathf.Lerp(StartSpeed, EndSpeed, (float)level / maxLevel);

        public float NextDifferenceSpeed(int level, int maxLevel)
        {
            if (level != maxLevel)
                return GetSpeed(level + 1, maxLevel) - GetSpeed(level, maxLevel);

            return 0;
        }

        public float StartSpeed;
        public float EndSpeed;
    }
}