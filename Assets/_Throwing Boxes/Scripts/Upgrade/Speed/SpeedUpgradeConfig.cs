﻿using System;
using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "SpeedUpgradeConfig", menuName = "Configs/Upgrades/SpeedUpgradeConfig", order = 57)]
    public class SpeedUpgradeConfig : UpgradeConfig
    {
        public SpeedUpgradeTable SpeedTable;
    }
}