using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerModel _playerModel;
        
        [SerializeField]
        private List<QuestCondition> _questConditions;
        
        [SerializeField]
        private HeroUpgradesManager _heroUpgradesManager;
        
        [SerializeField]
        private SkillManager _skillManager;
        
        public override void InstallBindings()
        {
            BindFromInstance<PlayerModel>(_playerModel);
            
            foreach (var questCondition in _questConditions)
            {
                Container.Inject(questCondition);
            }
            
            BindFromInstance<IHeroUpgradesManager>(_heroUpgradesManager);
            BindFromInstance<ISkillManager>(_skillManager);
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