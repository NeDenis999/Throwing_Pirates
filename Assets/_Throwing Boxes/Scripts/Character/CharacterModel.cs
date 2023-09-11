using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Throwing_Boxes
{
    public class CharacterModel : MonoBehaviour, IGrable
    {
        [SerializeField]
        private Movement _movement;
        
        [SerializeField]
        private Grabbing _grabbing;

        [SerializeField]
        private CharacterView _view;
        
        private Vector2ReactiveProperty _inputDirection = new();

        private void Awake()
        {
            _inputDirection.Subscribe(direction =>
            {
                if (direction == Vector2.zero)
                {
                    _view.IdlePlay();
                }
                else
                {
                    _view.MovePlay(direction);
                }
            });
        }

        private void Update()
        {
            if (_inputDirection.Value != Vector2.zero)
                _movement.Move(_inputDirection.Value);
        }

        public void GrableOnPerformed(InputAction.CallbackContext obj)
        {
            if (_grabbing.TryGrab(out var box))
            {

            }
        }
        
        public void DropOnPerformed(InputAction.CallbackContext obj)
        {
            if (_grabbing.TryDrop())
            {

            }
        }
        
        public void MovementOnPerformed(InputAction.CallbackContext context)
        {
            _inputDirection.Value = context.ReadValue<Vector2>();
        }
        
        public void MovementOnCanceled(InputAction.CallbackContext obj)
        {
            _inputDirection.Value = Vector2.zero;
        }
        
        public void Grable()
        {
            _view.transform.eulerAngles = new Vector3(0, 0, 90);
        }

        public async void Lay()
        {
            await Task.Delay(500);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            _view.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        public async void Drop()
        {
            await Task.Delay(500);
            Lay();
        }
    }
}