using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public interface IMoveInDirectionMotor
    {
        event Action OnStartMove;

        event Action OnStopMove;

        bool IsMoving { get; }

        Vector3 Direction { get; }

        bool CanMove(Vector3 direction);

        void RequestMove(Vector3 direction);

        void Interrupt();
    }
}