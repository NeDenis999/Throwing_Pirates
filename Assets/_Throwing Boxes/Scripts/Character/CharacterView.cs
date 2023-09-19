using Sirenix.OdinInspector;
using UnityEngine;

namespace Throwing_Boxes
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private Transform _carcass;
        
        [SerializeField]
        private Animator _animator;
        
        public void MovePlay(Vector2 direction)
        {
            if (direction.x > 0)
            {
                _carcass.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.x < 0)
            {
                _carcass.localScale = new Vector3(-1, 1, 1);
            }
            
            _animator.SetFloat("Speed", 1);
        }

        public void IdlePlay()
        {
            _animator.SetFloat("Speed", 0);
        }

        public void JumpPlay()
        {
            _animator.SetTrigger("Jump");
        }

        [Button]
        public void GrablePlay()
        {
            _animator.SetTrigger("Grable");
        }

        public void NotGrablePlay()
        {
            _animator.SetTrigger("NotGrable");
        }

        public void HitPlay()
        {
            _animator.SetTrigger("Hit");
        }

        public void AimPlay()
        {
            _animator.SetBool("IsAim", true);
        }

        public void AimStop()
        {
            _animator.SetBool("IsAim", false);
        }
    }
}