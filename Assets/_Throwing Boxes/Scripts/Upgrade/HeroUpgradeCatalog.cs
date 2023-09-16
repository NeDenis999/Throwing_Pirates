using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "HeroUpgradeCatalog", menuName = "Configs/Upgrades/HeroUpgradeCatalog", order = 56)]
    public class HeroUpgradeCatalog : ScriptableObject
    {
        public List<UpgradeConfig> Configs;

        [Inject]
        private void Construct(DiContainer container)
        {
            foreach (var config in Configs)
            {
                container.Inject(config);
            }
        }

        public T GetConfig<T>() where  T : UpgradeConfig
        {
            foreach (var config in Configs)
            {
                if (config.GetType() == typeof(T))
                    return (T)config;
            }

            throw new Exception("Тип не найден");
        }
    }
}