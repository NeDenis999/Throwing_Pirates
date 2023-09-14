using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Throwing_Boxes
{
    public abstract class CharacterModel : MonoBehaviour, IGrable
    {
        public event Action<float> HealthUpdate;
        
        [SerializeField]
        [Tooltip("Компонент перемещения")]
        private Movement _movement;

        [SerializeField]
        private CharacterView _view;

        [SerializeField]
        //[Randomize(1f, 100f)]
        private float _health;
        
        [SerializeField]
        private float _damage;
        
        private Vector2ReactiveProperty _moveDirection = new();

        public float GetHealth => _health;
        
        private void Awake()
        {
            _moveDirection.Subscribe(direction =>
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
            if (_moveDirection.Value != Vector2.zero)
                _movement.Move(_moveDirection.Value);
        }

        public abstract void GrableOnPerformed(InputAction.CallbackContext obj);

        public abstract void DropOnPerformed(InputAction.CallbackContext obj);
        
        public void MovementOnPerformed(InputAction.CallbackContext context)
        {
            _moveDirection.Value = context.ReadValue<Vector2>();
        }
        
        public void MovementOnCanceled(InputAction.CallbackContext obj)
        {
            _moveDirection.Value = Vector2.zero;
        }
        
        public void JumpOnPerformed(InputAction.CallbackContext obj)
        {
            _view.JumpPlay();
        }
        
        public void Grable()
        {
            _view.transform.eulerAngles = new Vector3(0, 0, 90);
        }

        public async void Lay()
        {
            await Task.Delay(500);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
            await Task.Delay(500);
            _view.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        public async void Drop()
        {
            await Task.Delay(500);
            Lay();
        }
        
        public void SetSpeed(float speed)
        {
            _movement.Speed = speed;
        }
        
        public void SetHealth(float health)
        {
            _health = health;
            HealthUpdate?.Invoke(_health);
        }
        
        public void SetDamage(float damage)
        {
            _damage= damage;
        }
    }
}