using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Throwing_Boxes
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private CharacterInventory _inventory;

        [SerializeField]
        private List<CellView> _cellViews;

        private List<CellViewModel> _cellViewModels = new();

        private void Start()
        {
            for (int i = 0; i < _cellViews.Count; i++)
            {
                var viewMode = new CellViewModel(_inventory, _cellViews[i]);
                viewMode.Initialize(i);
                _cellViewModels.Add(viewMode);
                _cellViewModels[i].UpdateCellView();
            }
            
            _inventory.SlotNumber.Subscribe(SelectSlot);
        }
        
        private void SelectSlot(int number)
        {
            for (int i = 0; i < _cellViewModels.Count; i++)
            {
                if (i == number)
                    _cellViewModels[i].Select();
                else
                    _cellViewModels[i].Deselect();
            }
        }
    }
}