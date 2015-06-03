using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace RPG.Inventory.Base
{
    public class TotalWeightContainer : Container
    {
        protected decimal Total;
        protected decimal Sum = 0;
        public TotalWeightContainer(int capacaty, decimal total) : base(capacaty)
        {
            Total = total;
        }

        public override bool AddItem(Item itemToAdd)
        {
            foreach (var item in Items)
            {
                if (item != null)
                {
                    Sum += item.Weight;
                }
            }
            if (itemToAdd.Weight + Sum <= Total)
            {
                return base.AddItem(itemToAdd);
            }
            return false;
        }
    }
}