using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Throwing_Boxes
{
    public class MeleeCombatAction : Actor
    {
        [SerializeField]
        private Blackboard _blackboard;

        [Range(0, 5)]
        [SerializeField]
        private int _cost;

        private Coroutine _coroutine;

        public override bool IsValid()
        {
            return _blackboard.HasVariable(BlackboardKeys.UNIT) && 
                   _blackboard.HasVariable(BlackboardKeys.ENEMY);
        }

        public override int EvaluateCost()
        {
            return _cost;
        }

        override protected void Play()
        {
            var unit = _blackboard.GetVariable<CharacterModel>(BlackboardKeys.UNIT);
            var enemy = _blackboard.GetVariable<CharacterModel>(BlackboardKeys.ENEMY);

            _coroutine = StartCoroutine(MeleeCombat(unit, enemy));
        }

        protected void OnDisable()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator MeleeCombat(CharacterModel unit, CharacterModel enemy)
        {
            var combat = unit.GetComponent<MeleeCombat>();
            combat.StopCombat();
            combat.StartCombat(enemy);
            
            while (combat.IsCombat)
            {
                yield return  new WaitForFixedUpdate();
            }
            
            Return(true);
        }
    }
}