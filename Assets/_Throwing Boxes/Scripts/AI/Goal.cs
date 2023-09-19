using UnityEngine;

namespace Throwing_Boxes
{
    public abstract class Goal : MonoBehaviour, IGoal
    {
        public IFactState ResultState
        {
            get { return _resultState; }
        }

        [SerializeField]
        private FactState _resultState;

        public abstract bool IsValid();

        public abstract int EvaluatePriority();
    }
}