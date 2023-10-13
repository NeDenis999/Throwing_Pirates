using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private MoneyBank _moneyBank;

        [SerializeField]
        private UIManager _uiManager;

        public override void InstallBindings()
        {
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