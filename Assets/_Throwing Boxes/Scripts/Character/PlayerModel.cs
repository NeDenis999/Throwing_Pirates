using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Throwing_Boxes
{
    public class PlayerModel : CharacterModel
    {
                
        [SerializeField]
        private Grabbing _grabbing;

        public override void GrableOnPerformed(InputAction.CallbackContext obj)
        {
            if (_grabbing.TryGrab(out var box))
            {

            }
        }
        
        public override void DropOnPerformed(InputAction.CallbackContext obj)
        {
            if (_grabbing.TryDrop())
            {

            }
        }
    }
}