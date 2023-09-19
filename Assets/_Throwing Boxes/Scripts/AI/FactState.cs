using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Throwing_Boxes
{
    [Serializable]
    public sealed class FactState : IFactState, IEnumerable
    {
        [SerializeField]
        private Fact[] _variables;

        public FactState(params Fact[] variables)
        {
            _variables = variables;
        }

        public bool GetFact(string id)
        {
            for (int i = 0, count = this._variables.Length; i < count; i++)
            {
                var variable = this._variables[i];
                if (variable.Id == id)
                {
                    return variable.Value;
                }
            }

            throw new Exception($"Variable with {id} is not found");
        }

        public bool TryGetFact(string id, out bool value)
        {
            for (int i = 0, count = _variables.Length; i < count; i++)
            {
                var variable = _variables[i];
                if (variable.Id == id)
                {
                    value = variable.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        public bool ContainsFact(string id)
        {
            for (int i = 0, count = _variables.Length; i < count; i++)
            {
                var variable = _variables[i];
                if (variable.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<KeyValuePair<string, bool>> GetEnumerator()
        {
            for (int i = 0, count = _variables.Length; i < count; i++)
            {
                var variable = _variables[i];
                yield return new KeyValuePair<string, bool>(variable.Id, variable.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}