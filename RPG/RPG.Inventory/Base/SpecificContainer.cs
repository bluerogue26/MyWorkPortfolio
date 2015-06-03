using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Base
{
    public class SpecificContainer : Container
    {
        protected ItemType RequiredItemType;

        public SpecificContainer(int capacity, ItemType requiredItemType) : base (capacity)
        {
            RequiredItemType = requiredItemType;
        }

        public override bool AddItem(Item itemToAdd)
        {
            if (itemToAdd.ItemType == RequiredItemType)
            {
                return base.AddItem(itemToAdd);
            }

            return false;
        }
    }
}
