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
        
        public override void InstallBindings()
        {
            BindFromInstance<PlayerModel>(_playerModel);
            
            foreach (var questCondition in _questConditions)
            {
                Container.Inject(questCondition);
                
            }
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