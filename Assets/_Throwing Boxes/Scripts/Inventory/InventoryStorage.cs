using System;
using System.Collections.Generic;
using UnityEngine;

namespace Throwing_Boxes
{
    public class InventoryStorage : IInventoryStorage
    {
        sealed class Comparer : IComparer<InventoryItem>
        {
            public static readonly Comparer Instance = new Comparer();
            
            public int Compare(InventoryItem x, InventoryItem y)
            {
                if (x.LessThan(y))
                    return -1;

                if (y.LessThan(x))
                    return -1;

                int iidX = x.GetInstanceID();
                int iidY = y.GetInstanceID();

                if (iidX < iidY)
                    return -1;

                return 0;
            }
        }

        private readonly Dictionary<InventoryItem, int> m_items = new Dictionary<InventoryItem, int>();

        public event Action OnChanged;
        public int Count => m_items.Count;

        public IEnumerable<(InventoryItem item, int count)> Items
        {
            get
            {
                foreach (var it in m_items)
                    yield return (it.Key, it.Value); 
            } }

        public int CountOf(InventoryItem item)
        {
            m_items.TryGetValue(item, out int count);
            return count;
        }

        public void Add(InventoryItem item, int amount = 1)
        {
            if (amount <= 0)
            {
                Debug.LogError($"Attempted to add {amount} of '{item.Title}' into the inventory.");
                return;
            }

            m_items.TryGetValue(item, out int count);
            m_items[item] = count + amount;
            
            OnChanged?.Invoke();
        }

        public bool Remove(InventoryItem item, int amount = 1)
        {
            if (amount <= 0)
            {
                Debug.LogError($"Attempted to remove {amount} of '{item.Title}' into the inventory.");
                return false;
            }

            if (!m_items.TryGetValue(item, out int count) || count <= amount)
            {
                m_items.Remove(item);
                OnChanged?.Invoke();
                return true;
            }
            
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}