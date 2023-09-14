using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Throwing_Boxes
{
    public class HeartManager : MonoBehaviour
    {
        [SerializeField]
        private HeartView _viewPrefab;

        [SerializeField]
        private Transform _viewsContainer;

        private PlayerModel _playerModel;
        private List<HeartView> _views = new();

        [Inject]
        private void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void Awake()
        {
            _playerModel.HealthUpdate += OnHealthUpdate;
        }

        private void Start()
        {
            HealthUpdate();
        }

        private void OnDestroy()
        {
            _playerModel.HealthUpdate -= OnHealthUpdate;
        }

        private void OnHealthUpdate(float health)
        {
            if ((int)health != _views.Count)
            {
                HealthUpdate();
            }
        }

        private void HealthUpdate()
        {
            DestroyUpgrades();
            CreateUpgrades();
        }
        
        private void CreateUpgrades()
        {
            var count = (int)_playerModel.GetHealth;

            _views = new List<HeartView>();

            for (int i = 0; i < count; i++)
            {
                var view = Instantiate(_viewPrefab, _viewsContainer);
                _views.Add(view);
            }
        }
        
        private void DestroyUpgrades()
        {
            var count = _views.Count;

            for (int i = 0; i < count; i++)
            {
                var view = _views[i];
                Destroy(view.gameObject);
            }
        }
    }
}