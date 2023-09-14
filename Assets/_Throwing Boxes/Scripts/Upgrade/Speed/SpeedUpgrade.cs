using Zenject;

namespace Throwing_Boxes
{
    public class SpeedUpgrade : HeroUpgrade
    {
        private readonly SpeedUpgradeConfig _config;
        
        private PlayerModel _playerModel;
        
        public SpeedUpgrade(SpeedUpgradeConfig config) : base(config)
        {
            _config = config;
        }
        
        public override string CurrentStatus => 
            $"{_config.SpeedTable.GetSpeed(Level, MaxLevel)}";
        
        public override string NextImprovement =>
            _config.SpeedTable.NextDifferenceSpeed(Level, MaxLevel).ToString();

        public override string CurrentStats { get; }

        override public void Initialize(PlayerModel playerModel, int level)
        {
            _playerModel = playerModel;
            SetSpeed(level);
        }

        override protected void UpgradeLevel(int level)
        {
            SetSpeed(level);
        }

        private void SetSpeed(int level)
        {
            var speed = _config.SpeedTable.GetSpeed(level, MaxLevel);
            _playerModel.SetSpeed(speed);
        }
    }
}