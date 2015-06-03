using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.Prod
{
    public class OrderRepository : IOrderDataRepository
    {

        private const string LogPath = @"DataFiles/Log.txt";

        public List<Order> ReadFile(string date) 
        {
            List<Order> orders = new List<Order>();

            var reader = File.ReadAllLines(date);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();

                order.OrderNumber = int.Parse(columns[0]);
                order.CustomerName = columns[1];
                order.Taxes.StateAbbreviation = columns[2];
                order.Taxes.TaxRate = decimal.Parse(columns[3]);
                order.Product.ProductType = columns[4];
                order.Area = decimal.Parse(columns[5]);
                order.Product.CostPerSquareFoot = decimal.Parse(columns[6]);
                order.Product.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                order.MaterialCost = decimal.Parse(columns[8]);
                order.LaborCost = decimal.Parse(columns[9]);
                order.Tax = decimal.Parse(columns[10]);
                order.Total = decimal.Parse(columns[11]);

                orders.Add(order);
            }
            return orders;
        }

        public Order LoadOrder(int orderNumber, string date)
        {
            var reader = File.ReadAllLines(date);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = new Order();

                order.OrderNumber = int.Parse(columns[0]);
                order.CustomerName = columns[1];
                order.Taxes.StateAbbreviation = columns[2];
                order.Taxes.TaxRate = decimal.Parse(columns[3]);
                order.Product.ProductType = columns[4];
                order.Area = decimal.Parse(columns[5]);
                order.Product.CostPerSquareFoot = decimal.Parse(columns[6]);
                order.Product.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                order.MaterialCost = decimal.Parse(columns[8]);
                order.LaborCost = decimal.Parse(columns[9]);
                order.Tax = decimal.Parse(columns[10]);
                order.Total = decimal.Parse(columns[11]);

                if (order.OrderNumber == orderNumber)
                    return order;
            }
            return null;
        }

        public List<Order> CheckFiles(string date)
        {
            if (File.Exists(date))
            {
                var orders = ReadFile(date);
                return orders;
            }
            else
            {
                return null;
            }
        }

        public void AddToFile(Order newOrder, string date)
        {
            var orderList = ReadFile(date);

            orderList.Add(newOrder);

            OverWriteFile(orderList, date);
        }

        public void EditFile(Order alteredOrder, string date)
        {
            var orderList = ReadFile(date);

            var orderIndex = orderList.FindIndex(x => x.OrderNumber == alteredOrder.OrderNumber);

            orderList[orderIndex] = alteredOrder;

            OverWriteFile(orderList, date);
        }

        public void OverWriteFile(List<Order> orders, string date)
        {
            if (File.Exists(date))
            {
                File.Delete(date);
            }

            using (var sw = File.CreateText(date))
            {
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var order in orders)
                {
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName, order.Taxes.StateAbbreviation, order.Taxes.TaxRate, order.Product.ProductType, order.Area, order.Product.CostPerSquareFoot, order.Product.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
                }
            }
        }

        public void DeleteFile(int orderNum, string date)
        {
            var orderList = ReadFile(date);

            var orderIndex = orderList.FindIndex(x => x.OrderNumber == orderNum);

            orderList.RemoveAt(orderIndex);

            if (orderList.Count == 0)
            {
                File.Delete(date);
            }
            else
            {
                OverWriteFile(orderList, date);
            }
        }

        public void MessageToLog(string message)
        {
            if(!(File.Exists(LogPath)))
            {
                File.Create(LogPath);
            }

            using (var sw = File.AppendText(LogPath))
            {
                sw.WriteLine(message);
            }
        }
    }

}
