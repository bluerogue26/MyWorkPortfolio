using RPG.Inventory.Base;
namespace RPG.Inventory.Items.Containers
{
    public class PlasticBag : TotalWeightContainer
    {
        public PlasticBag() : base(10, 10)
        {
            Name = "Plastic Bag";
            Weight = 0.1M;
            ItemType = ItemType.Container;
        }
    }
}