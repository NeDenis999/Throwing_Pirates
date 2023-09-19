using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Throwing_Boxes
{
    [AddComponentMenu("AI/GOAP/Goal Oriented Agent")]
    [DisallowMultipleComponent]
    public class GoalOrientedAgent : MonoBehaviour, IActor.Callback
    {
        public event Action OnStarted;

        public event Action OnFailed;

        public event Action OnCanceled;

        public event Action OnCompleted;
        
        [SerializeField, Space, PropertyOrder(-10)]
        private WorldState _worldState;
        
        [SerializeField, Space, PropertyOrder(-9)]
        private Goal[] _goals;
        
        [ShowInInspector, ReadOnly, PropertyOrder(-5)]
        private List<IActor> _currentPlan;

        [ShowInInspector, ReadOnly, PropertyOrder(-4)]
        private int _actionIndex;
        
        [SerializeField, Space, PropertyOrder(-8)]
        private Actor[] _actions;
        
        [ShowInInspector, ReadOnly, PropertyOrder(-6)]
        public IGoal CurrentGoal
        {
            get { return this._currentGoal; }
        }
        
        [Title("Debug")]
        [ShowInInspector, ReadOnly, PropertySpace, PropertyOrder(-7)]
        public bool IsPlaying
        {
            get { return this._currentPlan != null; }
        }
        
        private IPlanner _planner;
        private Goal _currentGoal;
        
        private void Awake()
        {
            this.ConstructActions();
            this.ConstructPlanner();
        }
        
        public void Invoke(IActor action, bool success)
        {
            if (!success)
            {
                this.Fail();
                return;
            }

            var planCompleted = this._actionIndex + 1 >= this._currentPlan.Count;
            if (planCompleted)
            {
                this.Complete();
                return;
            }

            this._actionIndex++;
            this.StartCoroutine(this.PlayNextAction());
        }
        
        private IEnumerator PlayNextAction()
        {
            yield return new WaitForFixedUpdate();
            this._currentPlan[this._actionIndex].Play(callback: this);
        }
        
        private void Fail()
        {
            this._currentPlan = null;
            this._actionIndex = 0;
            this.OnFail();
        }
        
        private void Complete()
        {
            this._currentPlan = null;
            this._actionIndex = 0;
            this.OnComplete();
        }
        
        protected virtual void OnFail()
        {
            this.OnFailed?.Invoke();
        }

        protected virtual void OnComplete()
        {
            this.OnCompleted?.Invoke();
        }

        protected virtual void OnCancel()
        {
            this.OnCanceled?.Invoke();
        }
        
        public IEnumerable<IGoal> AllGoals
        {
            get { return this._goals; }
        }

        public IEnumerable<IActor> AllActions
        {
            get { return this._actions; }
        }
        
        private bool CreatePlan()
        {
            _worldState.UpdateFacts();

            var goal = _goals
                .Where(it => it.IsValid())
                .OrderByDescending(it => it.EvaluatePriority())
                .First();

            if (_planner.MakePlan(_worldState, goal.ResultState, out var plan))
            {
                _currentGoal = goal;
                _currentPlan = plan;
                return true;
            }

            Debug.LogWarning($"Can't make a plan for goal {goal.name}!");
            return false;
        }
        
        [Button]
        public void Play()
        {
            if (_actions.Length == 0)
            {
                Debug.LogWarning("Can't play: no walid actions!");
                return;
            }
            
            if (!CreatePlan())
            {
                return;
            }

            if (_currentPlan.Count <= 0)
            {
                return;
            }

            _actionIndex = 0;
            OnStarted?.Invoke();
            _currentPlan[_actionIndex].Play(callback: this);
        }
        
        private void ConstructActions()
        {
            foreach (var action in _actions)
            {
                action.Construct(_worldState);
            }
        }

        public void Cancel()
        {
            if (this._currentPlan != null)
            {
                this._currentPlan[this._actionIndex].Cancel();
            }

            this._currentPlan = null;
            this._actionIndex = 0;
            this.OnCancel();
        }
        
        public void Replay()
        {
            this.Cancel();
            this.Play();
        }
        
        private void ConstructPlanner()
        {
            this._planner = PlannerFactory.CreatePlanner(_actions);
        }

        public bool TryPlay()
        {
            if (!this.IsPlaying)
            {
                this.Play();
                return true;
            }

            return false;
        }
    }
}