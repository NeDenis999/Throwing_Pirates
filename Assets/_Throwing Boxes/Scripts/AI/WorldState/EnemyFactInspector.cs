using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public sealed class EnemyFactInspector : FactInspector
    {
        [SerializeField]
        private Blackboard _blackboard;

        [SerializeField]
        [BlackboardKey]
        private string _atEnemyKey;
        
        [SerializeField]
        [BlackboardKey]
        private string _nearEnemyKey;
        
        [SerializeField]
        [BlackboardKey]
        private string _hasEnemyKey;
        
        public override void OnUpdate(WorldState worldState)
        {
            if (_blackboard.TryGetVariable(BlackboardKeys.UNIT, out CharacterModel unit) &&
                _blackboard.TryGetVariable(BlackboardKeys.ENEMY, out CharacterModel enemy))
            {
                float atDistance = _blackboard.GetVariable<float>(BlackboardKeys.AT_ENEMY_DISTANCE);
                float nearDistance = _blackboard.GetVariable<float>(BlackboardKeys.NEAR_ENEMY_DISTANCE);

                float distance = EntityUtils.Distance(unit, enemy);
                bool atEnemy = distance <= atDistance;
                bool isNear = distance <= nearDistance;

                worldState.SetFact(_atEnemyKey, atEnemy);
                worldState.SetFact(_nearEnemyKey, isNear);
                worldState.SetFact(_hasEnemyKey, true);
            }
            else
            {
                worldState.RemoveFact(_atEnemyKey);
                worldState.RemoveFact(_nearEnemyKey);
                worldState.RemoveFact(_hasEnemyKey);
            }
        }
    }
}