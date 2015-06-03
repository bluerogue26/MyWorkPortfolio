using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Reagents
{
    public class Mushroom : Item
    {
        public Mushroom()
        {
            Name = "Red and White Speckled Mushroom";
            Weight = 0.1M;
            ItemType = ItemType.Reagent;
        }
    }
}
