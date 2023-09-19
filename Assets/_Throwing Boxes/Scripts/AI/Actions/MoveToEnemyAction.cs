using System.Collections;
using UnityEngine;

namespace Throwing_Boxes
{
    public class MoveToEnemyAction : Actor
    {
        [SerializeField]
        private Blackboard _blackboard;

        private Coroutine _coroutine;
        private MoveAgent _moveAgent;

        public override bool IsValid()
        {
            return _blackboard.HasVariable(BlackboardKeys.UNIT) && 
                   _blackboard.HasVariable(BlackboardKeys.ENEMY);
        }

        public override int EvaluateCost()
        {
            var unit = _blackboard.GetVariable<CharacterModel>(BlackboardKeys.UNIT);
            var enemy = _blackboard.GetVariable<CharacterModel>(BlackboardKeys.ENEMY);
            var stoppingDistance = _blackboard.GetVariable<float>(BlackboardKeys.AT_ENEMY_DISTANCE);

            var distance = EntityUtils.Distance(unit, enemy);
            distance = Mathf.Max(distance - stoppingDistance, 0);
            return Mathf.RoundToInt(distance);
        }

        override protected void Play()
        {
            var unit = _blackboard.GetVariable<CharacterModel>(BlackboardKeys.UNIT);
            var enemy = _blackboard.GetVariable<CharacterModel>(BlackboardKeys.ENEMY);
            var stoppingDistance = _blackboard.GetVariable<float>(BlackboardKeys.AT_ENEMY_DISTANCE);
            var enemyTransform = enemy.transform;
            
            _moveAgent = unit.GetComponent<MoveAgent>();
            _moveAgent.SetUnit(unit);
            _moveAgent.SetStoppingDistance(stoppingDistance);
            _moveAgent.SetTargetPosiiton(enemy.transform);
            _moveAgent.Play();

            _coroutine = StartCoroutine(MoveToEnemy(enemyTransform));
        }

        override protected void OnDispose()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            
            _moveAgent.Stop();
        }

        private IEnumerator MoveToEnemy(Transform target)
        {
            while (_moveAgent.IsMove)
            {
                _moveAgent.SetTargetPosiiton(target);
                yield return new WaitForFixedUpdate();
            }
            
            Return(true);
        }
    }
}