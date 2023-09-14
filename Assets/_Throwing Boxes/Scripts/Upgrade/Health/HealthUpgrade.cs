namespace Throwing_Boxes
{
    public class HealthUpgrade : HeroUpgrade
    {
        private readonly HealthUpgradeConfig _config;
        
        private PlayerModel _playerModel;
        
        public HealthUpgrade(HealthUpgradeConfig config) : base(config)
        {
            _config = config;
        }
        
        public override string CurrentStatus => 
            $"{_config.HealthTable.GetHealth(Level)}";
        
        public override string NextImprovement =>
            _config.HealthTable.NextDifferenceHealth(Level, MaxLevel).ToString();

        public override string CurrentStats { get; }

        override public void Initialize(PlayerModel playerModel, int level)
        {
            _playerModel = playerModel;
            SetHealth(level);
        }

        override protected void UpgradeLevel(int level)
        {
            SetHealth(level);
        }

        private void SetHealth(int level)
        {
            var health = _config.HealthTable.GetHealth(level);
            _playerModel.SetHealth(health);
        }
    }
}