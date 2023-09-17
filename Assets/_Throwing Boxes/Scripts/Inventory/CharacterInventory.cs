using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine.InputSystem;
using Zenject;

namespace Throwing_Boxes
{
    public class CharacterInventory : AbstractInventory
    {
        public ReactiveProperty<int> SlotNumber;
        private PlayerModel _playerModel;

        [Inject]
        private void Construct(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void Start()
        {
            SelectItem(0);
        }

        private void SelectItem(int number)
        {
            SlotNumber.Value = number;

            if (TryGetItem(number, out var item))
            {
                _playerModel.SetWeapon(item.Item.Prefab);
            }
            else
            {
                _playerModel.SetWeapon(null);
            }
        }

        public InitialItem[] Items()
        {
            var items = new List<InitialItem>();
            
            foreach (var item in Storage.Items)
            {
                var newItem = new InitialItem();
                newItem.Item = item.item;
                newItem.Count = item.count;
                items.Add(newItem);
            }

            return items.ToArray();
        }

        public void InventorySlot1(InputAction.CallbackContext obj)
        {
            SelectItem(0);
        }
        
        public void InventorySlot2(InputAction.CallbackContext obj)
        {
            SelectItem(1);
        }
        
        public void InventorySlot3(InputAction.CallbackContext obj)
        {
            SelectItem(2);
        }
        
        public void InventorySlot4(InputAction.CallbackContext obj)
        {
            SelectItem(3);
        }
        
        public void InventorySlot5(InputAction.CallbackContext obj)
        {
            SelectItem(4);
        }

        public void DropItem(InputAction.CallbackContext obj)
        {
            if (TryGetItem(SlotNumber.Value, out var item))
            {
                if (Storage.Remove(item.Item, 1))
                {
                    SelectItem(SlotNumber.Value);
                }
            }
        }

        private bool TryGetItem(int number, out InitialItem item)
        {
            item = new InitialItem();
            
            if (number >= Items().Count())
                return false;

            item = Items()[number];
            return true;
        }
    }
}