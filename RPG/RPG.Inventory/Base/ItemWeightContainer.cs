namespace RPG.Inventory.Base
{
    public class ItemWeightContainer : Container
    {
        protected decimal BagWeight;

        public ItemWeightContainer(int capacity, decimal weight) : base (capacity)
        {
            BagWeight = weight;
        }

        public override bool AddItem(Item itemToAdd)
        {
            if (itemToAdd.Weight <= BagWeight)
            {
                return base.AddItem(itemToAdd);
            }

            return false;
        }
    }
}