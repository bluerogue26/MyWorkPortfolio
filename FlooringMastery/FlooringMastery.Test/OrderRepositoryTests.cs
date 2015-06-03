using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Models;
using NUnit.Framework;
using System.IO;
using FlooringMastery.BLL;
using FlooringMastery.Data.Prod;

namespace FlooringMastery.Test
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        [Test]
        public void LoadOrders()
        {
            var orderManager = ManagerFactory.CreateOrderManager();

            string date = @"DataFiles\Orders_06012013.txt";

            var orders = orderManager.CheckFiles(date);

            var order = orders.SingleOrDefault(x => x.OrderNumber == 1);

            Assert.AreEqual(order.OrderNumber, 1);
        }

        [Test]
        public void NullOrder()
        {
            var orderManager = ManagerFactory.CreateOrderManager();

            string date = @"DataFiles\Orders_06012012.txt";

            var orders = orderManager.CheckFiles(date);

            Assert.IsNull(orders);
        }

        [Test]
        public void NewFileOrder()
        {
            var orderManager = ManagerFactory.CreateOrderManager();

            var order = new Order
            {
                Area = 100M,
                CustomerName = "Wise",
                LaborCost = 475.00M,
                MaterialCost = 515.00M,
                OrderNumber = 1,
                Product = new Product
                {
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,
                    ProductType = "Wood"
                },
                Tax = 61.88M,
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    StateName = "Ohio",
                    TaxRate = 0.0625M
                },
                Total = 1501.88M
            };

            string date = @"DataFiles\Orders_06012012.txt";

            var orderList = new List<Order>(){order};

            orderManager.OverWriteFile(orderList, date);

            var orders = orderManager.CheckFiles(date);

            var newOrder = orders.SingleOrDefault(x => x.OrderNumber == 1);

            Assert.AreEqual(newOrder.OrderNumber, 1);

            File.Delete(date);
        }

        [Test]
        public void AddToFileOrder()
        {
            var orderManager = ManagerFactory.CreateOrderManager();

            var order = new Order
            {
                Area = 100M,
                CustomerName = "Wise",
                LaborCost = 475.00M,
                MaterialCost = 515.00M,
                OrderNumber = 2,
                Product = new Product
                {
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,
                    ProductType = "Wood"
                },
                Tax = 61.88M,
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    StateName = "Ohio",
                    TaxRate = 0.0625M
                },
                Total = 1501.88M
            };

            string date = @"DataFiles\Orders_06012013.txt";

            orderManager.AddToFile(order, date);

            var orders = orderManager.CheckFiles(date);

            var newOrder = orders.SingleOrDefault(x => x.OrderNumber == 2);

            Assert.AreEqual(newOrder.OrderNumber, 2);
        }

        [Test]
        public void FindSingleFile()
        {
            var orderManager = new OrderRepository();

            int orderNum = 1;

            string date = @"DataFiles\Orders_06012013.txt";

            var order = orderManager.LoadOrder(orderNum, date);

            Assert.AreEqual(order.CustomerName, "Wise");
        }

        [Test]
        public void EditFile()
        {
            var orderManager = ManagerFactory.CreateOrderManager();

            var order = new Order
            {
                Area = 100M,
                CustomerName = "Bananas",
                LaborCost = 475.00M,
                MaterialCost = 515.00M,
                OrderNumber = 1,
                Product = new Product
                {
                    CostPerSquareFoot = 5.15M,
                    LaborCostPerSquareFoot = 4.75M,
                    ProductType = "Wood"
                },
                Tax = 61.88M,
                Taxes = new Taxes
                {
                    StateAbbreviation = "OH",
                    StateName = "Ohio",
                    TaxRate = 0.0625M
                },
                Total = 1501.88M
            };

            string date = @"DataFiles\Orders_06012013.txt";

            orderManager.EditFile(order, date);

            var newOrder = orderManager.LoadOrder(1, date);

            Assert.AreEqual(newOrder.CustomerName, "Bananas");

            newOrder.CustomerName = "Wise";

            orderManager.EditFile(newOrder, date);
        }
    }
}
