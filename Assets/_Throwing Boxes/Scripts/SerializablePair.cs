using System;
using UnityEngine;

namespace Throwing_Boxes
{
    [Serializable]
    public struct SerializablePair<TKey, TValue>
    {
        [field: SerializeField] public TKey Key { get; private set; }
        [field: SerializeField] public TValue Value { get; private set; }
    }
}