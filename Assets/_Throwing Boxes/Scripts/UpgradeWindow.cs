using UnityEngine;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class UpgradeWindow : BaseWindow
    {
        [SerializeField]
        private UpgradeViewManager _upgradeViewManager;

        [SerializeField]
        private SkillViewManager _skillViewManager;

        [SerializeField]
        private Button _openSkillButton;
        
        [SerializeField]
        private Button _openUpgradeButton;

        private void OnEnable()
        {
            _openSkillButton.onClick.AddListener(OpenSkill);
            _openUpgradeButton.onClick.AddListener(OpenUpgrade);
        }

        private void OnDisable()
        {
            _openSkillButton.onClick.RemoveListener(OpenSkill);
            _openUpgradeButton.onClick.RemoveListener(OpenUpgrade);
        }

        private void Start()
        {
            OpenUpgrade();
        }

        private void OpenSkill()
        {
            if (_upgradeViewManager.gameObject.activeSelf)
                _upgradeViewManager.Hide();
            
            _skillViewManager.Show();

            _openSkillButton.interactable = false;
            _openUpgradeButton.interactable = true;
        }
        
        private void OpenUpgrade()
        {
            _upgradeViewManager.Show();
            
            if (_skillViewManager.gameObject.activeSelf)
                _skillViewManager.Hide();
            
            _openSkillButton.interactable = true;
            _openUpgradeButton.interactable = false;
        }
    }
}