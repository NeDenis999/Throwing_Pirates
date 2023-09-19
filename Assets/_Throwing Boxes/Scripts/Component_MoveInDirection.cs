using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class Component_MoveInDirection : IComponent_MoveInDirection
    {
        public event Action OnStarted
        {
            add { this.engine.OnStartMove += value; }
            remove { this.engine.OnStartMove -= value; }
        }

        public event Action OnStopped
        {
            add { this.engine.OnStopMove += value; }
            remove { this.engine.OnStopMove -= value; }
        }

        public bool IsMoving
        {
            get { return this.engine.IsMoving; }
        }

        private readonly IMoveInDirectionMotor engine;

        public Component_MoveInDirection(IMoveInDirectionMotor engine)
        {
            this.engine = engine;
        }

        public bool CanMove(Vector3 direction)
        {
            return this.engine.CanMove(direction);
        }

        public void Move(Vector3 direction)
        {
            this.engine.RequestMove(direction);
        }
    }
}