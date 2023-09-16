using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _moneyText;

        private IMoneyBank _moneyBank;

        [Inject]
        private void Construct(IMoneyBank moneyBank)
        {
            _moneyBank = moneyBank;
        }

        private void OnEnable()
        {
            _moneyBank.OnMoneyChanged += UpdateMoneyText;
        }

        private void OnDisable()
        {
            _moneyBank.OnMoneyChanged -= UpdateMoneyText;
        }

        private void Start()
        {
            UpdateMoneyText(_moneyBank.Money, _moneyBank.Money, null);
        }

        private void UpdateMoneyText(int arg1, int arg2, object arg3)
        {
            _moneyText.text = $"Деньги: {arg2}";
        }
    }
}