using UnityEngine;

namespace Throwing_Boxes
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField]
        private Animator _animator;
        
        public void MovePlay(Vector2 direction)
        {
            if (direction.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                _spriteRenderer.flipX = true;
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
    }
}