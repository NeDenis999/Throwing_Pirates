using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "QuestConditionsInstaller", menuName = "Configs/Quest/QuestConditionsInstaller", order = 55)]
    public class QuestConditionsInstaller : ScriptableObjectInstaller
    {
        [SerializeField]
        private List<QuestCondition> _questConditions;

        public override void InstallBindings()
        {
            foreach (var questCondition in _questConditions)
            {
                BindFromInstance(questCondition);
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