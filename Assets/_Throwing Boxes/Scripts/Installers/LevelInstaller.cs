using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerModel _playerModel;
        
        [SerializeField]
        private List<QuestCondition> _questConditions;
        
        [SerializeField]
        private HeroUpgradesManager _heroUpgradesManager;
        
        [SerializeField]
        private MoneyBank _moneyBank;

        [SerializeField]
        private UIManager _uiManager;
        
        public override void InstallBindings()
        {
            BindFromInstance<PlayerModel>(_playerModel);
            
            foreach (var questCondition in _questConditions)
            {
                Container.Inject(questCondition);
            }
            
            BindFromInstance<IHeroUpgradesManager>(_heroUpgradesManager);
            BindFromInstance<IMoneyBank>(_moneyBank);
            BindFromInstance(_uiManager);
        }

        private void BindFromInstance<T>(T instance)
        {
            Container
                .Bind<T>()
                .FromInstance(instance)
                .AsSingle()
                .NonLazy();
        }
    }
}