using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "Inventory Item", menuName = "Configs/Inventory/Inventory Item", order = 60)]
    public class InventoryItem : ScriptableObject
    {
        public InventoryCategory Category;
        public string Title;
        public string Description;
        public Sprite Icon;
        public GameObject Prefab;

        public bool LessThan(InventoryItem other)
        {
            return Title.CompareTo(other.Title) < 0;
        }
    }
}