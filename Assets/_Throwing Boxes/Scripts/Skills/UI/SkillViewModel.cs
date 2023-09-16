using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Throwing_Boxes
{
    public class SkillViewModel : IDisposable
    {
        private readonly SkillView _skillView;
        private readonly Skill _skill;

        private SkillViewManager _skillViewManager;
        private bool _isBlock;
        private PlayerModel _playerModel;
        
        public bool IsOpen => !_isBlock;

        public SkillViewModel(SkillView skillView, Skill skill)
        {
            _skillView = skillView;
            _skill = skill;
            
            _skillView.Button.onClick.AddListener(() => _skillViewManager.SelectSkillViewModel(this));
        }
        
        public void Dispose()
        {
            _skillView.Button.onClick.RemoveListener(() => _skillViewManager.SelectSkillViewModel(this));
        }

        public void Initialize(SkillViewManager skillViewManager, PlayerModel playerModel)
        {
            _skillViewManager = skillViewManager;
            _skillView.SetIcon(_skill.Icon);
            _playerModel = playerModel;
            _isBlock = !IsOpenSkill(_skill);
            
            if (_isBlock)
                _skillView.ShowBlockImage();
            else
                _skillView.HideBlockImage();
        }
        
        public void Open()
        {
            if (!_isBlock)
                return;
            
            _skillView.HideBlockImage();
            _isBlock = false;
            _playerModel.DamageSkills.Add((DamageSkill)_skill);
        }

        public string GetTitle()
        {
            return _skill.Title;
        }

        public void Select()
        {
            _skillView.SetFrameIconSelect();
        }

        public void Deselect()
        {
            _skillView.SetFrameIconDeselect();
        }
        
        private bool IsOpenSkill(Skill skill)
        {
            foreach (var damageSkill in _playerModel.DamageSkills)
            {
                if (damageSkill == skill)
                    return true;
            }

            return false;
        }
    }
}