using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Containers
{
    public class SmallPocketBag : ItemWeightContainer
    {
        public SmallPocketBag() : base(7, 2)
        {
            Name = "Bag with Small Pockets";
            Weight = 1M;
            ItemType = ItemType.Container;
        }
    }
}