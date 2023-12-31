﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Throwing_Boxes
{
    public class PlayerModel : CharacterModel
    {
        [SerializeField]
        private Grabbing _grabbing;

        [SerializeField]
        public List<DamageSkill> DamageSkills = new();

        public override void AdditionalActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (_grabbing.TryGrab(out var box))
            {
                _view.GrablePlay();
            }
        }
        
        public override void MainActionOnPerformed(InputAction.CallbackContext obj)
        {
            if (_grabbing.TryDrop())
            {
                _view.NotGrablePlay();
            }
            else
            {
                _view.HitPlay();
            }
        }
    }
}