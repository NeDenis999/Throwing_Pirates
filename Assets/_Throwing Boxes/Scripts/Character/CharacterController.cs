using UniRx;
using UnityEngine;

namespace Throwing_Boxes
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private ReactiveProperty<CharacterModel> _characterModel = new ReactiveProperty<CharacterModel>();

        #region MyRegion

        

        #endregion
        private PlayerInputActions _playerInputActions;
        private CharacterModel _previousCharacterModel;
        
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
                }
                
                _playerInputActions.Player.Movement.performed += _characterModel.Value.MovementOnPerformed;
                _playerInputActions.Player.Movement.canceled += _characterModel.Value.MovementOnCanceled;
                _playerInputActions.Player.Grable.performed += _characterModel.Value.GrableOnPerformed;
                _playerInputActions.Player.Drop.performed += _characterModel.Value.DropOnPerformed;

                _previousCharacterModel = _characterModel.Value;
            });

            _characterModel.Value = _characterModel.Value;
        }
    }
}