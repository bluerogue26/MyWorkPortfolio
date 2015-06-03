using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Data.Prod;
using FlooringMastery.Models;
using NUnit.Framework;

namespace FlooringMastery.Test
{
    [TestFixture]
    public class OrderOperationsTest
    {
        [Test]
        public void AddAccountToExisting()
        {
            var manager = new OrderOperations();
            var dataManager = new OrderRepository();

            var state = new Taxes
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 0.0625M
            };

            var product = new Product
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            };

            DateTime date = new DateTime(2013,6,1);

            decimal area = 100.00M;
            var response = manager.CreateOrder("Wi,se", state, product, area, date);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Data.OrderNumber, 2);
            Assert.AreEqual(response.Data.CustomerName, "Wi,se");

            string newDate = DateToStringConverter.DateToString(date);

            dataManager.DeleteFile(2, newDate);
        }

        [Test]
        public void AddAccountToNew()
        {
            var manager = new OrderOperations();

            var state = new Taxes
            {
                StateAbbreviation = "OH",
                StateName = "Ohio",
                TaxRate = 0.0625M
            };

            var product = new Product
            {
                ProductType = "Wood",
                CostPerSquareFoot = 5.15M,
                LaborCostPerSquareFoot = 4.75M
            };

            DateTime date = new DateTime(2010, 6, 1);

            decimal area = 100.00M;
            var response = manager.CreateOrder("Wise", state, product, area, date);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Data.OrderNumber, 1);

            File.Delete(@"DataFiles\Orders_06012010.txt");
        }

        [Test]
        public void FindSingleAccount()
        {
            var manager = new OrderOperations();

            DateTime date = new DateTime(2013,6,1);

            var response = manager.LoadOrder(1, date);

            Assert.IsTrue(response.Success);

            Assert.AreEqual(response.Data.CustomerName, "Wise");
        }

        [Test]
        public void FindNoAccount()
        {
            var manager = new OrderOperations();

            DateTime date = new DateTime(2013, 6, 1);

            var response = manager.LoadOrder(2, date);

            Assert.IsFalse(response.Success);
        }
    }
}
