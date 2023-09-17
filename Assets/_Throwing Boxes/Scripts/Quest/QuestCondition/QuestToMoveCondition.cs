using System;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "QuestToMoveCondition", menuName = "Configs/Quest/QuestCondition/Quest To Move Condition", order = 52)]
    public class QuestToMoveCondition : QuestCondition
    {
        public Vector2 TargetPoint;
        public float Distance;

        [Inject] private PlayerModel _playerModel;

        public override bool IsTrue()
        {
            return ((Vector2)_playerModel.transform.position - TargetPoint).magnitude < Distance;
        }

        public override string GetCondition()
        {
            return $"{Math.Round(((Vector2)_playerModel.transform.position - TargetPoint).magnitude)}";
        }
    }
}