using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data.Test
{
    public class TestOrderRepository : IOrderDataRepository
    {
        public List<Order> ReadFile(string date)
        {
            return new List<Order>
            {
                new Order{
                    Area = 100,
                CustomerName = "Wise",
                Date = "06/01/2013",
                LaborCost = 475.00M,
                MaterialCost = 515.00M,
                OrderNumber = 1,
                Product = new Product() {CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M, ProductType = "Wood"},
                Taxes = new Taxes() {StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M},
                Tax = 61.88M,
                Total = 1051.88M}
            };
        }

        public Order LoadOrder(int orderNumber, string date)
        {
            return new Order
            {
                Area = 100,
                CustomerName = "Wise",
                Date = "06/01/2013",
                LaborCost = 475.00M,
                MaterialCost = 515.00M,
                OrderNumber = 1,
                Product =
                    new Product() {CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M, ProductType = "Wood"},
                Taxes = new Taxes() {StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M},
                Tax = 61.88M,
                Total = 1051.88M
            };
        }

        public List<Order> CheckFiles(string date)
        {
            return new List<Order>
            {
                new Order{
                    Area = 100,
                CustomerName = "Wise",
                Date = "06/01/2013",
                LaborCost = 475.00M,
                MaterialCost = 515.00M,
                OrderNumber = 1,
                Product = new Product() {CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M, ProductType = "Wood"},
                Taxes = new Taxes() {StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M},
                Tax = 61.88M,
                Total = 1051.88M}
            };
        }

        public void AddToFile(Order newOrder, string date)
        {
            return;
        }

        public void EditFile(Order alteredOrder, string date)
        {
            return;
        }

        public void OverWriteFile(List<Order> orders, string date)
        {
            return;
        }

        public void DeleteFile(int orderNum, string date)
        {
            return;
        }

        public void MessageToLog(string message)
        {
            return;
        }
    }
}
