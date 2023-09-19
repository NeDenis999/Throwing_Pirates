using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Throwing_Boxes
{
    public class WorldState : MonoBehaviour, IFactState
    {
        [ShowInInspector]
        [ReadOnly]
        private readonly Dictionary<string, bool> _facts = new();
        
        [Space]
        [SerializeField]
        private FactInspector[] _inspectors;
        
        public void SetFact(string key, bool value)
        {
            _facts[key] = value;
        }
        
        public void RemoveFact(string key)
        {
            _facts.Remove(key);
        }
        
        [Button]
        public void UpdateFacts()
        {
            for (int i = 0, count = _inspectors.Length; i < count; i++)
            {
                var inspector = _inspectors[i];
                inspector.OnUpdate(this);
            }
        }

        public IEnumerator<KeyValuePair<string, bool>> GetEnumerator()
        {
            return _facts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool GetFact(string id)
        {
            return _facts[id];
        }

        public bool TryGetFact(string id, out bool value)
        {
            return _facts.TryGetValue(id, out value);
        }

        public bool ContainsFact(string id)
        {
            return _facts.ContainsKey(id);
        }
    }
}