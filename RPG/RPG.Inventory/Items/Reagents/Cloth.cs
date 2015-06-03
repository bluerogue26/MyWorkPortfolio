using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Reagents
{
    public class Cloth : Item
    {
        public Cloth()
        {
            Name = "Linen Cloth";
            Weight = 0.5M;
            ItemType = ItemType.Reagent;
        }
    }
}
