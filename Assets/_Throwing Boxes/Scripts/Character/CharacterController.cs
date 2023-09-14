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
                    _playerInputActions.Player.Grable.performed -= _previousCharacterModel.GrableOnPerformed;
                    _playerInputActions.Player.Drop.performed -= _previousCharacterModel.DropOnPerformed;
                    _playerInputActions.Player.Jump.performed -= _previousCharacterModel.JumpOnPerformed;
                    _playerInputActions.Player.Upgrades.performed -= OpenUpdateLevel;
                    _playerInputActions.Player.Menu.performed -= OpenMenu;
                }
                
                _playerInputActions.Player.Movement.performed += _characterModel.Value.MovementOnPerformed;
                _playerInputActions.Player.Movement.canceled += _characterModel.Value.MovementOnCanceled;
                _playerInputActions.Player.Grable.performed += _characterModel.Value.GrableOnPerformed;
                _playerInputActions.Player.Drop.performed += _characterModel.Value.DropOnPerformed;
                _playerInputActions.Player.Jump.performed += _characterModel.Value.JumpOnPerformed;
                _playerInputActions.Player.Upgrades.performed += OpenUpdateLevel;
                _playerInputActions.Player.Menu.performed += OpenMenu;

                _previousCharacterModel = _characterModel.Value;
            });

            _characterModel.Value = _characterModel.Value;
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