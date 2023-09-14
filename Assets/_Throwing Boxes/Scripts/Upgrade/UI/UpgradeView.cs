using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class UpgradeView : MonoBehaviour
    {
        private const string UPGRADE_COLOR_HEX = "30901E";

        [SerializeField]
        private Image _iconImage;

        [Space]
        [SerializeField]
        private TextMeshProUGUI _titleText;
        
        [SerializeField]
        private TextMeshProUGUI _valueText;
        
        [SerializeField]
        private TextMeshProUGUI _levelText;

        public UpgradeButton UpgradeButton;

        public void SetIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void SetTitle(string title)
        {
            _titleText.text = title;
        }

        public void SetValue(string stats, string profit = null)
        {
            var text = $"Value: {stats}";

            if (profit != null)
            {
                text += $" <color=#{UPGRADE_COLOR_HEX}>(+{profit})</color>";
            }

            _valueText.text = text;
        }

        public void SetLevel(int currentLevel, int maxLevel)
        {
            _levelText.text = $"Level: {currentLevel}/{maxLevel}";
        }
    }
}