using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class CellView : MonoBehaviour
    {
        [SerializeField]
        private Image _frame;
        
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private TextMeshProUGUI _countText;

        [SerializeField]
        private Sprite _frameSelectSprite;
        
        [SerializeField]
        private Sprite _frameDeselectSprite;
        
        public void ShowIcon()
        {
            _icon.gameObject.SetActive(true);
        }

        public void HideIcon()
        {
            _icon.gameObject.SetActive(false);
        }

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }

        public void SetCount(string count)
        {
            _countText.text = count;
        }

        public void SelectFrame()
        {
            _frame.sprite = _frameSelectSprite;
        }

        public void DeselectFrame()
        {
            _frame.sprite = _frameDeselectSprite;
        }
    }
}