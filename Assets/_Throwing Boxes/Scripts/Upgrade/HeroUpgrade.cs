using System;
using Unity.Collections;
using UnityEngine;

namespace Throwing_Boxes
{
    public abstract class HeroUpgrade : IHeroUpgrade
    {
        public event Action<int> OnLevelUp;
        
        public int Level { get; private set; } = 1;

        public string Id
        {
            get { return _config.Id; }
        }

        public int MaxLevel => _config.MaxLevel;

        public string Title => _config.Metadata.Title;

        public virtual string CurrentStatus => 
            _currentStatus;

        public virtual string NextImprovement { get; }

        public Sprite Icon => _config.Metadata.Icon;

        public int NextPrice => 
            _config.PriceTable.Value + _config.PriceTable.Value * _config.PriceTable.BasePowerPrice * Level + 1;
        public abstract string CurrentStats { get; }

        private UpgradeConfig _config;
        private string _currentStatus;

        protected HeroUpgrade(UpgradeConfig config)
        {
            _config = config;
        }

        public void Setup(int level)
        {
            Level = level;
        }

        public void IncrementLevel()
        {
            if (Level >= MaxLevel)
            {
                throw new Exception($"Can not increment level for ungrade {_config.Id}");
            }

            var nextLevel = Level + 1;
            UpgradeLevel(nextLevel);
            Level = nextLevel;
            OnLevelUp?.Invoke(nextLevel);
        }
        
        protected abstract void UpgradeLevel(int level);
        public abstract void Initialize(PlayerModel playerModel, int level);
    }
}