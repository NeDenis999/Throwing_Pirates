using UnityEngine;

namespace Throwing_Boxes
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        
        public void Move(Vector2 vectorMove)
        {
            transform.position += (Vector3)vectorMove.normalized * (_speed * Time.deltaTime);
        }
    }
}