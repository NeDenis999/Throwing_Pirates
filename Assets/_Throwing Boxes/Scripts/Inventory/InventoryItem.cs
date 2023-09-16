using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "Inventory Item", menuName = "Configs/Inventory Item", order = 60)]
    public class InventoryItem : ScriptableObject
    {
        public InventoryCategory Category;
        public string Title;
        public string Description;
        public Sprite Icon;

        public bool LessThan(InventoryItem other)
        {
            return Title.CompareTo(other.Title) < 0;
        }
    }
}