using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class UpgradeViewManager : BaseWindow
    {
        [SerializeField]
        private UpgradeView _viewPrefab;

        [SerializeField]
        private Transform _viewsContainer;

        private IHeroUpgradesManager _upgradesManager;
        private IMoneyBank _moneyBank;
        private List<UpgradeViewModel> _viewModels;
        private List<UpgradeView> _views;

        [Inject]
        private void Construct(IMoneyBank moneyBank, IHeroUpgradesManager upgradesManager)
        {
            _moneyBank = moneyBank;
            _upgradesManager = upgradesManager;
        }
        
        public override void Show()
        {
            base.Show();
            CreateUpgrades();
        }
        
        public override void Hide()
        {
            DestroyUpgrades();
            base.Hide();
        }

        private void CreateUpgrades()
        {
            var upgrades = _upgradesManager.GetAllUpgrades();
            var count = upgrades.Length;

            _views = new List<UpgradeView>();
            _viewModels = new List<UpgradeViewModel>(count);

            for (int i = 0; i < count; i++)
            {
                var view = Instantiate(_viewPrefab, _viewsContainer);
                _views.Add(view);

                var model = upgrades[i];
                var viewModel = new UpgradeViewModel(view, model);
                
                viewModel.Initialize(_upgradesManager, _moneyBank);
                _viewModels.Add(viewModel);
            }
        }
        
        private void DestroyUpgrades()
        {
            var count = _viewModels.Count;

            for (int i = 0; i < count; i++)
            {
                var controller = _viewModels[i];
                controller.Dispose();

                var view = _views[i];
                Destroy(view.gameObject);
            }
        }
    }
}