using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Throwing_Boxes
{
    public class CellViewModel : IDisposable
    {
        private readonly CharacterInventory _model;
        private readonly CellView _view;
        
        private int _number;

        public CellViewModel(CharacterInventory model, CellView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize(int number)
        {
            _number = number;

            _model.Storage.OnChanged += UpdateCellView;
        }

        public void Dispose()
        {
            _model.Storage.OnChanged -= UpdateCellView;
        }
        
        public void Select()
        {
            _view.SelectFrame();
        }

        public void Deselect()
        {
            _view.DeselectFrame();
        }

        public void UpdateCellView()
        {
            if (_model.Items().Count() <= _number)
            {
                _view.SetCount(0.ToString());
                _view.HideIcon();
                return;
            }

            var item = _model.Items()[_number];
            _view.ShowIcon();
            _view.SetIcon(item.Item.Icon);
            _view.SetCount(item.Count.ToString());
        }
    }
}