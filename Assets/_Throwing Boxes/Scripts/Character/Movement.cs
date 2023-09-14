using UnityEngine;

namespace Throwing_Boxes
{
    public class Movement : MonoBehaviour
    {
        public float Speed;
        
        public void Move(Vector2 vectorMove)
        {
            transform.position += (Vector3)vectorMove.normalized * (Speed * Time.deltaTime);
        }
    }
}