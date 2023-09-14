using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class UpgradeButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _priceText;
        
        [SerializeField]
        private Button _button;

        private State _state;
        
        public void AddListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }
        
        public void RemoveListener(UnityAction action)
        {
            _button.onClick.AddListener(action);
        }

        public void SetState(State state)
        {
            _state = state;
        }

        public enum State
        {
            AVAILABE,
            LOCKED,
            MAX
        }

        public void SetPrice(string priceText)
        {
            _priceText.text = "UPGRADE\n" + priceText;
        }
    }
}