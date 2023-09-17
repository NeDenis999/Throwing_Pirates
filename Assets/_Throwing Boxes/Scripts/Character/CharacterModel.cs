using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Throwing_Boxes
{
    public abstract class CharacterModel : MonoBehaviour
    {
        public event Action<float> HealthUpdate;
        
        [SerializeField]
        [Tooltip("Компонент перемещения")]
        private Movement _movement;

        [SerializeField]
        protected CharacterView _view;

        [SerializeField]
        //[Randomize(1f, 100f)]
        private float _health;
        
        [SerializeField]
        private float _damage;
        
        [SerializeField]
        private CharacterInventory _inventory;

        [SerializeField]
        private Transform _weaponPoint;
        
        private Vector2ReactiveProperty _moveDirection = new();
        private GameObject _weapon;

        public float GetHealth => _health;
        public CharacterInventory Inventory => _inventory;

        public bool IsBurn;

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

        public abstract void AdditionalActionOnPerformed(InputAction.CallbackContext obj);

        public abstract void MainActionOnPerformed(InputAction.CallbackContext obj);
        
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

        public void Aim()
        {
            _view.AimPlay();
        }

        public void AdditionalActionOnCanceled(InputAction.CallbackContext obj)
        {
            _view.AimStop();
        }
        
        public void Damage(float damage)
        {
            _health -= damage;
            HealthUpdate?.Invoke(_health);
        }

        public void SetWeapon(GameObject weaponPrefab)
        {
            if (_weapon)
                Destroy(_weapon);
            
            if (weaponPrefab == null)
                return;
            
            var weapon = Instantiate(weaponPrefab, _weaponPoint);
            _weapon = weapon;
        }
    }
}