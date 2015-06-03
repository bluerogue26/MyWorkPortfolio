using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Inventory.Base;

namespace RPG.Inventory.Items.Weapons
{
    public class BattleAxe : Item
    {
        public BattleAxe()
        {
            Name = "Battle Axe";
            Weight = 4;
            ItemType = ItemType.Weapon;
        }
    }
}
