using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Throwing_Boxes
{
    public class Blackboard : MonoBehaviour
    {
        public event Action<string, object> OnVariableAdded;
        
        [ShowInInspector]
        [ReadOnly]
        private readonly Dictionary<string, object> _variables = new Dictionary<string, object>();

        public bool TryGetVariable<T>(string key, out T value)
        {
            if (_variables.TryGetValue(key, out var result))
            {
                value = (T) result;
                return true;
            }

            value = default;
            return false;
        }
        
        public T GetVariable<T>(string key)
        {
            if (!_variables.TryGetValue(key, out var result))
            {
                throw new Exception($"{key} value is not found!");
            }

            return (T) result;
        }
        
        [Title("Methods")]
        [Button]
        public void AddVariable(string key, object value)
        {
            if (_variables.ContainsKey(key))
            {
                throw new Exception($"Variable {key} is already added!");
            }

            _variables.Add(key, value);
            OnVariableAdded?.Invoke(key, value);
        }

        public bool HasVariable(string key)
        {
            return _variables.ContainsKey(key);
        }
    }
}