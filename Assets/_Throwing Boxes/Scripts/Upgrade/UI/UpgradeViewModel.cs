using System;

namespace Throwing_Boxes
{
    public class UpgradeViewModel : IDisposable
    {
        private readonly IHeroUpgrade _upgrade;
        private readonly UpgradeView _view;
        private IHeroUpgradesManager _upgradesManager;
        private IMoneyBank _moneyBank;

        public UpgradeViewModel(UpgradeView view, IHeroUpgrade upgrade)
        {
            _upgrade = upgrade;
            _view = view;
        }

        public void Initialize(IHeroUpgradesManager upgradesManager, IMoneyBank moneyBank)
        {
            _upgradesManager = upgradesManager;
            _moneyBank = moneyBank;

            _upgrade.OnLevelUp += OnLevelUp;

            if (!_upgrade.IsMaxLevel())
            {
                _moneyBank.OnMoneyChanged += OnMoneyChanged;
            }
            
            _view.SetIcon(_upgrade.Icon);
            _view.SetTitle(_upgrade.Title);
            _view.UpgradeButton.AddListener(OnButtonClicked);
            UpdateState();
        }
        
        public void Dispose()
        {
            _upgrade.OnLevelUp -= OnLevelUp;
            _moneyBank.OnMoneyChanged -= OnMoneyChanged;
            _view.UpgradeButton.RemoveListener(OnButtonClicked);
        }

        #region Events

        private void OnButtonClicked()
        {
            if (_upgradesManager.CanLevelUp(_upgrade))
            {
                _moneyBank.Money -= _upgrade.NextPrice;
                _upgradesManager.LevelUp(_upgrade);
            }
        }

        private void OnLevelUp(int level)
        {
            UpdateState();
        }

        private void OnMoneyChanged(int previousValue, int newValue, object @event)
        {
            UpdateButtonState();
        }

        #endregion

        private void UpdateState()
        {
            _view.SetLevel(_upgrade.Level, _upgrade.MaxLevel);

            if (_upgrade.IsMaxLevel())
            {
                _view.SetValue(_upgrade.CurrentStatus);
                _view.UpgradeButton.SetState(UpgradeButton.State.MAX);
                _view.UpgradeButton.SetPrice("Max");
            }
            else
            {
                _view.SetValue(_upgrade.CurrentStatus, _upgrade.NextImprovement);

                var priceText = _upgrade.NextPrice.ToString();
                _view.UpgradeButton.SetPrice(priceText);
                UpdateButtonState();
            }
        }

        private void UpdateButtonState()
        {
            var state = _upgrade.NextPrice <= _moneyBank.Money
                ? UpgradeButton.State.AVAILABE
                : UpgradeButton.State.LOCKED;

            _view.UpgradeButton.SetState(state);
        }
    }
}