using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Base
{
    public abstract class Item
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Weapon,
        Armour,
        Potion,
        Reagent,
        Container
    }
}
