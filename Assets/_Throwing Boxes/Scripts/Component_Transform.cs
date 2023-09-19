using UnityEngine;

namespace Throwing_Boxes
{
    public sealed class Component_Transform : IComponent_GetPosition
    {
        private Transform _root;
        
        public Vector3 Position => 
            _root.position;
        
        public Component_Transform(Transform root)
        {
            _root = root;
        }
    }
}