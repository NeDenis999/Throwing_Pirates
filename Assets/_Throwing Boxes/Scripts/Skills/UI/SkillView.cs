using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Throwing_Boxes
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Image _frameIcon;

        [SerializeField]
        private Sprite _frameSelectSprite;
        
        [SerializeField]
        private Sprite _frameDiselectSprite;

        [SerializeField]
        private Button _button;

        private SkillViewManager _skillViewManager;
        private Skill _skill;

        private void OnEnable()
        {
            _button.onClick.AddListener(() => _skillViewManager.SelectSkillView(this));
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => _skillViewManager.SelectSkillView(this));
        }

        public void Initialize(SkillViewManager skillViewManager, Skill skill)
        {
            _skill = skill;
            _skillViewManager = skillViewManager;
            _icon.sprite = skill.Icon;
        }

        public void Select()
        {
            _frameIcon.sprite = _frameSelectSprite;
        }

        public void Deselect()
        {
            _frameIcon.sprite = _frameDiselectSprite;
        }

        public string GetTitle()
        {
            return _skill.Title;
        }
    }
}