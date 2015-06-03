using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Weapons
{
    public class WoodenSword : Item
    {
        public WoodenSword()
        {
            Name = "Wooden Sword";
            Weight = 2M;
            ItemType = ItemType.Weapon;
        }
    }
}
