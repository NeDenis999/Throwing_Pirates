using UnityEngine;

namespace Throwing_Boxes
{
    public class Grabbing : MonoBehaviour
    {
        [SerializeField]
        private Transform _grableTransform;

        [SerializeField]
        private float _forceDrop;
        
        public bool IsGrable => Grable != null;
        public IGrable Grable;
        
        public bool TryGrab(out IGrable grable)
        {
            grable = null;

            if (IsGrable)
            {
                Lay();
                Grable.Lay();
                return false;
            }

            var raycastAll = Physics2D.RaycastAll(transform.position, Vector2.zero, 
                10);

            foreach (var raycast in raycastAll)
            {
                if (raycast.collider.TryGetComponent<IGrable>(out var grable1))
                {
                    grable = grable1;
                    Grable = grable; 
                    
                    var grableTransform = raycast.collider.transform;
                    var rigidbody = grableTransform.GetComponent<Rigidbody2D>();
                    rigidbody.bodyType = RigidbodyType2D.Kinematic;
                    rigidbody.velocity = Vector2.zero;
                    raycast.collider.enabled = false;
                    grableTransform.parent = _grableTransform;
                    grableTransform.localPosition = Vector3.zero;
                    grable.Grable();
                    return true;
                }
            }
            
            return false;
        }

        private void Grab()
        {
            
        }

        private void Lay()
        {
            var DropObject = (MonoBehaviour)Grable;
            Grable = null;
            DropObject.transform.parent = null;
            var rigidbody = DropObject.GetComponent<Rigidbody2D>();
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            DropObject.GetComponent<Collider2D>().enabled = true;
        }
        
        public bool TryDrop()
        {
            if (!IsGrable)
                return false;

            var DropObject = (MonoBehaviour)Grable;
            Grable.Drop();
            Lay();
            DropObject.GetComponent<Rigidbody2D>().AddForce(GetDirection() * _forceDrop, 
                ForceMode2D.Impulse);
            return true;
        }

        private Vector2 GetDirection() =>
            (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
    }
}