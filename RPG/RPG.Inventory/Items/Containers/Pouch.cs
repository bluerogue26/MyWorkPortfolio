using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Containers
{
    public class Pouch : Container
    {
        public Pouch() : base(4)
        {
            Name = "Pouch";
            Weight = 0.5M;
            ItemType = ItemType.Container;
        }
    }
}
