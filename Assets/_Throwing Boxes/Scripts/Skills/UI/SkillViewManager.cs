using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class SkillViewManager : MonoBehaviour
    {
        [SerializeField]
        private SkillView _skillPrefab;

        [SerializeField]
        private Transform _viewsContainer;

        [SerializeField]
        private TextMeshProUGUI _titleText;
        
        private ISkillManager _skillManager;
        private List<SkillView> _skillViews;

        [Inject]
        private void Construct(ISkillManager skillManager)
        {
            _skillManager = skillManager;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            CreateUpgrades();
            SelectSkillView(_skillViews[0]);
        }

        public void Hide()
        {
            DestroyUpgrades();
            gameObject.SetActive(false);
        }

        private void CreateUpgrades()
        {
            var skills = _skillManager.GetAllSkills();
            var count = skills.Length;

            _skillViews = new List<SkillView>();

            for (int i = 0; i < count; i++)
            {
                var view = Instantiate(_skillPrefab, _viewsContainer);
                view.Initialize(this, skills[i]);
                _skillViews.Add(view);
            }
        }
        
        private void DestroyUpgrades()
        {
            var count = _skillViews.Count;

            for (int i = 0; i < count; i++)
            {
                var view = _skillViews[i];
                Destroy(view.gameObject);
            }
        }

        public void SelectSkillView(SkillView selectSkillView)
        {
            foreach (var skillView in _skillViews)
            {
                if (skillView == selectSkillView)
                {
                    skillView.Select();
                }
                else
                {
                    skillView.Deselect();
                }
            }

            _titleText.text = selectSkillView.GetTitle();
        }
    }
}