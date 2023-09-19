using UnityEngine;

namespace Throwing_Boxes
{
    public abstract class FactInspector : MonoBehaviour
    {
        public abstract void OnUpdate(WorldState worldState);
    }
}