using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPG.Inventory.Base;
using RPG.Inventory.Items.Containers;
using RPG.Inventory.Items.Reagents;
using RPG.Inventory.Items.Weapons;

namespace RPG.Inventory.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanPutItemInBag()
        {
            var p = new Pouch();
            p.AddItem(new BattleAxe());

            Assert.AreEqual(1, p.GetItemCount);
        }

        [Test]
        public void CanNotOverFill()
        {
            var p = new Pouch();
            Assert.AreEqual(true, p.AddItem(new BattleAxe()));
            Assert.AreEqual(true, p.AddItem(new BattleAxe()));
            Assert.AreEqual(true, p.AddItem(new BattleAxe()));
            Assert.AreEqual(true, p.AddItem(new BattleAxe()));
            Assert.AreEqual(false, p.AddItem(new BattleAxe()));

            p.DisplayContents();
        }

        [Test]
        public void CanRemoveItem()
        {
            var p = new Pouch();

            p.AddItem(new Mushroom());

            var item = p.RemoveItem();  // mushroom goes into item

            Assert.IsNotNull(item);
            Assert.IsInstanceOf(typeof(Mushroom), item);
        }

        [Test]
        public void EmptyBagReturnsNull()
        {
            var p = new Pouch();

            var item = p.RemoveItem();

            Assert.IsNull(item);
        }

        [Test]
        public void SpecificBagRejectsBadItem()
        {
            var bag = new ReagentBag();
            var axe = new BattleAxe();
            var result = bag.AddItem(axe);
            
            Assert.AreEqual(false, result);

        }

        [Test]
        public void SpecificBagAcceptsGoodItem()
        {
            var bag = new ReagentBag();
            var thing = new Cloth();
            var result = bag.AddItem(thing);

            Assert.AreEqual(true, result);
            Assert.AreEqual(1, bag.GetItemCount);

        }

        [Test]
        public void OverweightItemTest()
        {
            var bag = new SmallPocketBag();
            var axe = new BattleAxe();
            var result = bag.AddItem(axe);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void PerfectItemWeight()
        {
            var bag = new SmallPocketBag();
            Assert.AreEqual(true, bag.AddItem(new WoodenSword()));
            Assert.AreEqual(true, bag.AddItem(new Mushroom()));
            Assert.AreEqual(false, bag.AddItem(new BattleAxe()));
            Assert.AreEqual(2, bag.GetItemCount);
        }

        [Test]
        public void OverWeight()
        {
            var bag = new PlasticBag();
            Assert.AreEqual(true, bag.AddItem(new BattleAxe()));
            Assert.AreEqual(true, bag.AddItem(new BattleAxe()));
            Assert.AreEqual(false, bag.AddItem(new BattleAxe()));
        }
    }
}
