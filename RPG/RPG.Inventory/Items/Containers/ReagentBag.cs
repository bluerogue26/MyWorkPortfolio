using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Containers
{
    public class ReagentBag : SpecificContainer
    {
        public ReagentBag() : base(5, ItemType.Reagent)
        {
            Name = "Reagent Bag";
            Weight = 1M;
            ItemType = ItemType.Container;
        }
    }
}
