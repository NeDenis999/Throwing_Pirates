using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
        
        [SerializeField]
        private TextMeshProUGUI _statusText;
        
        [SerializeField]
        private Button _button;
        
        private ISkillManager _skillManager;
        private List<SkillView> _skillViews = new();
        private List<SkillViewModel> _skillViewModels = new();
        private SkillViewModel _selectSkillViewModel;
        private DiContainer _container;
        private PlayerModel _playerModel;

        [Inject]
        private void Construct(ISkillManager skillManager, DiContainer container, PlayerModel playerModel)
        {
            _skillManager = skillManager;
            _container = container;
            _playerModel = playerModel;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
            CreateUpgrades();
            SelectSkillViewModel(_skillViewModels[0]);
            
            _button.onClick.AddListener(OpenSkill);
        }

        public void Hide()
        {
            DestroyUpgrades();
            gameObject.SetActive(false);
            
            _button.onClick.RemoveListener(OpenSkill);
        }

        private void CreateUpgrades()
        {
            var skills = _skillManager.GetAllSkills();
            var count = skills.Length;

            _skillViews = new List<SkillView>();
            _skillViewModels = new List<SkillViewModel>();

            for (int i = 0; i < count; i++)
            {
                var view = Instantiate(_skillPrefab, _viewsContainer);
                _skillViews.Add(view);
                
                var model = skills[i];
                var viewModel = new SkillViewModel(view, model);
                
                viewModel.Initialize(this, _playerModel);
                _skillViewModels.Add(viewModel);
            }
        }
        
        private void DestroyUpgrades()
        {
            if (_skillViews == null)
                return;
            
            var count = _skillViews.Count;

            for (int i = 0; i < count; i++)
            {
                var view = _skillViews[i];
                Destroy(view.gameObject);
            }
        }

        public void SelectSkillViewModel(SkillViewModel selectSkillView)
        {
            foreach (var skillViewModel in _skillViewModels)
            {
                if (skillViewModel == selectSkillView)
                {
                    skillViewModel.Select();
                    _selectSkillViewModel = skillViewModel;

                    if (!skillViewModel.IsOpen)
                    {
                        _statusText.text = "Взять";
                        _button.interactable = true;
                    }
                    else
                    {
                        _statusText.text = "Открыт";
                        _button.interactable = false;
                    }
                }
                else
                {
                    skillViewModel.Deselect();
                }
            }

            _titleText.text = selectSkillView.GetTitle();
        }

        private void OpenSkill()
        {
            _selectSkillViewModel.Open();
        }
    }
}