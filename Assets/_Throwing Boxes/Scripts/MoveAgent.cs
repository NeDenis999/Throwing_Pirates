using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Throwing_Boxes
{
    public sealed class MoveAgent : Agent
    {
        [ShowInInspector, ReadOnly]
        private IEntity unit;

        [ShowInInspector, ReadOnly]
        private float stoppingDistance;

        [ShowInInspector, ReadOnly]
        private Vector3 targetPosiiton;

        //private IComponent_GetPosition positionComponent;

        //private IComponent_MoveInDirection moveComponent;
        
        private Coroutine moveCoroutine;
        private float _speed = 0.05f;
        
        [ShowInInspector, ReadOnly]
        private bool _isMove;
        public bool IsMove => 
            _isMove;

        [Button]
        public void SetTargetPosiiton(Transform point)
        {
            this.targetPosiiton = point.position;
        }

        [Button]
        public void SetTargetPosiiton(Vector3 position)
        {
            this.targetPosiiton = position;
        }

        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }

        [Button]
        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
            //this.positionComponent = unit?.Get<IComponent_GetPosition>();
            //this.moveComponent = unit?.Get<IComponent_MoveInDirection>();
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }
        
        override protected void OnStart()
        {
            this.moveCoroutine = this.StartCoroutine(this.MoveRoutine());
            _isMove = true;
        }

        override protected void OnStop()
        {
            if (this.moveCoroutine != null)
            {
                this.StopCoroutine(this.moveCoroutine);
                this.moveCoroutine = null;
                _isMove = false;
            }
        }

        private IEnumerator MoveRoutine()
        {
            var period = new WaitForFixedUpdate();

            while (Vector3.Distance(targetPosiiton, transform.position) > stoppingDistance)
            {
                if (this.unit != null)
                {
                    this.DoMove();
                }
                
                yield return period;
            }
            
            _isMove = false;
        }

        private void DoMove()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosiiton, _speed);

            /*var myPosition = this.positionComponent.Position;
            var distanceVector = this.targetPosiiton - myPosition;

            var isReached = distanceVector.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance;
            if (!isReached)
            {
                var moveDirection = distanceVector.normalized;
                this.moveComponent.Move(moveDirection);
            }
            else
            {
                Debug.Log("Position Reached");
            }*/
        }
    }
}