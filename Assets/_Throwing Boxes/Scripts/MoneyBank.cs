using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class MoneyBank : MonoBehaviour, IMoneyBank
    {
        public event Action<int, int, object> OnMoneyChanged;
        public int Money { get; set; }

        private void Awake()
        {
            Money = 99999;
        }
    }
}