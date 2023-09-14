namespace Throwing_Boxes
{
    public class DamageUpgrade : HeroUpgrade
    {
        private readonly DamageUpgradeConfig _config;
        
        private PlayerModel _playerModel;
        
        public DamageUpgrade(DamageUpgradeConfig config) : base(config)
        {
            _config = config;
        }
        
        public override string CurrentStatus => 
            $"{_config.DamageTable.GetDamage(Level)}";
        
        public override string NextImprovement =>
            _config.DamageTable.NextDifferenceDamage(Level, MaxLevel).ToString();

        public override string CurrentStats { get; }

        override public void Initialize(PlayerModel playerModel, int level)
        {
            _playerModel = playerModel;
            SetDamage(level);
        }

        override protected void UpgradeLevel(int level)
        {
            SetDamage(level);
        }

        private void SetDamage(int level)
        {
            var damage = _config.DamageTable.GetDamage(level);
            _playerModel.SetDamage(damage);
        }
    }
}