using System;
using UnityEngine;

namespace Throwing_Boxes
{
    [Serializable]
    public class Fact
    {
        [SerializeField]
        [BlackboardKey]
        public string Id;

        [SerializeField]
        public bool Value;

        public Fact(string id, bool value)
        {
            Id = id;
            Value = value;
        }
    }
}