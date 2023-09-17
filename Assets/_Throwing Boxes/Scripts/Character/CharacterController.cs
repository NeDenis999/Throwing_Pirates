using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Throwing_Boxes
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Управляемый персонаж суда можно вставить врага даже во время игры")]
        private ReactiveProperty<CharacterModel> _characterModel = new();

        private PlayerInputActions _playerInputActions;
        private CharacterModel _previousCharacterModel;
        private CharacterInventory _inventory;
        private UIManager _uiManager;

        [Inject]
        private void Construct(UIManager uiManager)
        {
            _uiManager = uiManager;
        }
        
        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();

            _characterModel.ObserveEveryValueChanged(x => x.Value).Subscribe(_ =>
            {
                if (_previousCharacterModel)
                {
                    _playerInputActions.Player.Movement.performed -= _previousCharacterModel.MovementOnPerformed;
                    _playerInputActions.Player.Movement.canceled -= _previousCharacterModel.MovementOnCanceled;
                    _playerInputActions.Player.AdditionalAction.performed -= _previousCharacterModel.AdditionalActionOnPerformed;
                    _playerInputActions.Player.AdditionalAction.canceled -= _characterModel.Value.AdditionalActionOnCanceled;
                    _playerInputActions.Player.MainAction.performed -= _previousCharacterModel.MainActionOnPerformed;
                    _playerInputActions.Player.Jump.performed -= _previousCharacterModel.JumpOnPerformed;
                    _playerInputActions.Player.Upgrades.performed -= OpenUpdateLevel;
                    _playerInputActions.Player.Menu.performed -= OpenMenu;
                    _playerInputActions.Player.InventorySlot1.performed -= _previousCharacterModel.Inventory.InventorySlot1;
                    _playerInputActions.Player.InventorySlot2.performed -= _previousCharacterModel.Inventory.InventorySlot2;
                    _playerInputActions.Player.InventorySlot3.performed -= _characterModel.Value.Inventory.InventorySlot3;
                    _playerInputActions.Player.InventorySlot4.performed -= _characterModel.Value.Inventory.InventorySlot4;
                    _playerInputActions.Player.InventorySlot5.performed -= _characterModel.Value.Inventory.InventorySlot5;
                    _playerInputActions.Player.DropItem.performed -= _characterModel.Value.Inventory.DropItem;
                }
                
                _playerInputActions.Player.Movement.performed += _characterModel.Value.MovementOnPerformed;
                _playerInputActions.Player.Movement.canceled += _characterModel.Value.MovementOnCanceled;
                _playerInputActions.Player.AdditionalAction.performed += _characterModel.Value.AdditionalActionOnPerformed;
                _playerInputActions.Player.AdditionalAction.canceled += _characterModel.Value.AdditionalActionOnCanceled;
                _playerInputActions.Player.MainAction.performed += _characterModel.Value.MainActionOnPerformed;
                _playerInputActions.Player.Jump.performed += _characterModel.Value.JumpOnPerformed;
                _playerInputActions.Player.Upgrades.performed += OpenUpdateLevel;
                _playerInputActions.Player.Menu.performed += OpenMenu;
                _playerInputActions.Player.InventorySlot1.performed += _characterModel.Value.Inventory.InventorySlot1;
                _playerInputActions.Player.InventorySlot2.performed += _characterModel.Value.Inventory.InventorySlot2;
                _playerInputActions.Player.InventorySlot3.performed += _characterModel.Value.Inventory.InventorySlot3;
                _playerInputActions.Player.InventorySlot4.performed += _characterModel.Value.Inventory.InventorySlot4;
                _playerInputActions.Player.InventorySlot5.performed += _characterModel.Value.Inventory.InventorySlot5;
                _playerInputActions.Player.DropItem.performed += _characterModel.Value.Inventory.DropItem;

                _previousCharacterModel = _characterModel.Value;
            });

            _characterModel.Value = _characterModel.Value;
        }

        private void Update()
        {
            if (_characterModel == null)
                return;
            
            if (_playerInputActions.Player.AdditionalAction.IsPressed())
            {
                _characterModel.Value.Aim();
            }
        }

        private void OpenUpdateLevel(InputAction.CallbackContext obj)
        {
            if (!_uiManager.IsShow(WindowType.UpdateLevel))
                _uiManager.Show(WindowType.UpdateLevel, null, false);
            else
                _uiManager.Hide(WindowType.UpdateLevel);
        }
        
        private void OpenMenu(InputAction.CallbackContext obj)
        {
            _uiManager.Show(WindowType.Setting, null, false);
        }
    }
}