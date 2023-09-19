using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class GoalOrientedLooper : MonoBehaviour
    {
        [SerializeField]
        private GoalOrientedAgent _goalOrientedAgent;

        private void FixedUpdate()
        {
            _goalOrientedAgent.TryPlay();
        }
    }
}