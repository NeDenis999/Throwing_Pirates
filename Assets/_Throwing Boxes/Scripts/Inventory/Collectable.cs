using System;

namespace Throwing_Boxes
{
    public class Collectable : AbstractInventory, ICollectible
    {
        public void Collect(IInventoryStorage otherStorage)
        {
            foreach (var item in Storage.Items)
                otherStorage.Add(item.item, item.count);
            
            Storage.Clear();
            Destroy(gameObject);
        }
    }
}