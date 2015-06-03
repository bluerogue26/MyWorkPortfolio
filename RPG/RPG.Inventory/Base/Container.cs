using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Base
{
    public abstract class Container : Item
    {
        protected int Capacity;
        protected Item[] Items;
        protected int CurrentIndex;

        public Container(int capacity)
        {
            Capacity = capacity;
            Items = new Item[capacity];
            CurrentIndex = 0;
        }

        public virtual bool AddItem(Item itemToAdd)
        {
            if (CurrentIndex < Capacity)
            {
                Items[CurrentIndex] = itemToAdd;
                CurrentIndex++;
                return true;
            }

            return false;
        }

        public Item RemoveItem()
        {
            if (GetItemCount > 0)
            {
                Item itemToReturn = Items[CurrentIndex - 1];
                CurrentIndex--;
                Items[CurrentIndex] = null;

                return itemToReturn;
            }

            return null;
        }

        public void DisplayContents()
        {
            Console.WriteLine("Items in {0}: ", Name);

            foreach (Item item in Items)
            {
                if (item != null)
                {
                    Console.WriteLine("{0} - {1} pounds", item.Name, item.Weight);
                }
            }
        }
        public int GetItemCount
        {
            get { return Items.Count(i => i != null); }
        }
    }
}
