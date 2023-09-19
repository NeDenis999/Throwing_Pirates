using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField]
        private Blackboard _blackboard;

        [SerializeField]
        float _atDistance = 1f;

        [SerializeField]
        float _nearDistance = 2f;
        
        [SerializeField]
        private CharacterModel _unit;

        [SerializeField]
        private CharacterModel _enemy;

        private void Start()
        {
            _blackboard.AddVariable(BlackboardKeys.UNIT, _unit);
            _blackboard.AddVariable(BlackboardKeys.ENEMY, _enemy);
            _blackboard.AddVariable(BlackboardKeys.AT_ENEMY_DISTANCE, _atDistance);
            _blackboard.AddVariable(BlackboardKeys.NEAR_ENEMY_DISTANCE, _nearDistance);
        }
    }
}