using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class HeroUpgradesManager : MonoBehaviour, IHeroUpgradesManager
    {
        [SerializeField]
        private HeroUpgradeCatalog _catalog;
        
        private UpgradeConfig HeroUpgradeConfig;
        private SpeedUpgrade _speedUpgrade;
        private HealthUpgrade _healthUpgrade;
        private DamageUpgrade _damageUpgrade;
        private PlayerModel _playerModel;
        private IMoneyBank _moneyBank;

        [Inject]
        private void Construct(PlayerModel playerModel, IMoneyBank moneyBank)
        {
            _playerModel = playerModel;
            _moneyBank = moneyBank;
        }

        private void Awake()
        {
            _speedUpgrade = new SpeedUpgrade(_catalog.GetConfig<SpeedUpgradeConfig>());
            _speedUpgrade.Initialize(_playerModel, 0);
            
            _healthUpgrade = new HealthUpgrade(_catalog.GetConfig<HealthUpgradeConfig>());
            _healthUpgrade.Initialize(_playerModel, 0);
            
            _damageUpgrade = new DamageUpgrade(_catalog.GetConfig<DamageUpgradeConfig>());
            _damageUpgrade.Initialize(_playerModel, 0);
        }

        [ContextMenu("UpgradeSpeed")]
        public void UpgradeSpeed()
        {
            _speedUpgrade.IncrementLevel();
        }

        public bool CanLevelUp(IHeroUpgrade upgrade) =>
            (_moneyBank.Money > upgrade.NextPrice && !upgrade.IsMaxLevel());

        public void LevelUp(IHeroUpgrade upgrade)
        {
            upgrade.IncrementLevel();
        }

        public IHeroUpgrade GetUpgrade(string id)
        {
            throw new System.NotImplementedException();
        }

        public IHeroUpgrade[] GetAllUpgrades()
        {
            var upgrades = new IHeroUpgrade[3];
            upgrades[0] = _speedUpgrade;
            upgrades[1] = _healthUpgrade;
            upgrades[2] = _damageUpgrade;
            return upgrades;
        }
    }
}