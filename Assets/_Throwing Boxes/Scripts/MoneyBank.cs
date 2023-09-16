using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class MoneyBank : MonoBehaviour, IMoneyBank
    {
        public event Action<int, int, object> OnMoneyChanged;

        private int _money;
        
        public int Money
        {
            get => _money;

            set
            {
                OnMoneyChanged?.Invoke(_money, value, null);
                _money = value;
            }
        }

        private void Awake()
        {
            Money = 99999;
        }
    }
}