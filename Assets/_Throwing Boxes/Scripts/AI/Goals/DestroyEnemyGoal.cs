using UnityEngine;

namespace Throwing_Boxes
{
    public class DestroyEnemyGoal : Goal
    {
        [SerializeField]
        private Blackboard _blackboard;

        [Space]
        [Range(0, 10)]
        [SerializeField]
        private int _priority;
        
        public override bool IsValid()
        {
            return _blackboard.HasVariable(BlackboardKeys.UNIT) && 
                   _blackboard.HasVariable(BlackboardKeys.ENEMY);
        }

        public override int EvaluatePriority()
        {
            return _priority;
        }
    }
}