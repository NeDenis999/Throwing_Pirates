using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public abstract class QuestCondition : ScriptableObject
    {
        public abstract bool IsTrue();

        public abstract string GetCondition();
    }
}