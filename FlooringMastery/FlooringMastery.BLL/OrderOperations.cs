using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data.Prod;
using FlooringMastery.Data.Test;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public class OrderOperations
    {
        public Response<Order> CreateOrder(string customer, Taxes state, Product product, decimal area, DateTime date)
        {
            var newOrder = new Order();
            var orderManager = ManagerFactory.CreateOrderManager();
            var response = new Response<Order>();

            try
            {
                newOrder.CustomerName = customer.Replace(",", "^*");
                newOrder.Area = area;
                newOrder.Taxes = state;
                newOrder.Product = product;
                newOrder.LaborCost = Math.Round((product.LaborCostPerSquareFoot*area),2);
                newOrder.MaterialCost = Math.Round((product.CostPerSquareFoot*area),2);
                newOrder.Tax = Math.Round(((newOrder.LaborCost + newOrder.MaterialCost)*(state.TaxRate/100)),2);
                newOrder.Total = Math.Round((newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax),2);

                string newDate = DateToStringConverter.DateToString(date);

                var orderList = orderManager.CheckFiles(newDate);

                if (orderList == null)
                {
                    var newList = new List<Order>();
                    newList.Add(newOrder);
                    newOrder.OrderNumber = 1;
                    orderManager.OverWriteFile(newList, newDate);
                }
                else
                {
                    newOrder.OrderNumber = orderList.Max(o => o.OrderNumber);
                    newOrder.OrderNumber++;

                    orderManager.AddToFile(newOrder, newDate);
                }

                response.Success = true;
                newOrder.Date = DateToStringConverter.FileToString(newDate);
                newOrder.CustomerName = customer.Replace("^*", ",");
                response.Data = newOrder;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                WriteErrorToLog(ex.Message);
            }

            return response;
        }

        public Response<Order> LoadOrder(int orderNum, DateTime date)
        {
            var order = new Order();
            var orderManager = ManagerFactory.CreateOrderManager();
            var response = new Response<Order>();

            var fileDate = DateToStringConverter.DateToString(date);

            try
            {
                order = orderManager.LoadOrder(orderNum, fileDate);

                if (order != null)
                {
                    response.Success = true;
                    order.Date = DateToStringConverter.FileToString(fileDate);
                    order.CustomerName = order.CustomerName.Replace("^*", ",");
                    response.Data = order;
                }
                else
                {
                    response.Success = false;
                    response.Message = "The order could not be found!";
                    WriteErrorToLog(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                WriteErrorToLog(ex.Message);
            }
            return response;
        }

        public Response<List<Order>> LoadAllOrders(DateTime date)
        {
            var orders = new List<Order>();
            var orderManager = ManagerFactory.CreateOrderManager();
            var response = new Response<List<Order>>();

            var newDate = DateToStringConverter.DateToString(date);

            try
            {
                orders = orderManager.CheckFiles(newDate);

                if (orders != null)
                {
                    response.Success = true;
                    foreach (var order in orders)
                    {
                        order.CustomerName = order.CustomerName.Replace("^*", ",");
                    }
                    response.Data = orders;
                }
                else
                {
                    response.Success = false;
                    response.Message = "File not found!";
                    WriteErrorToLog(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                WriteErrorToLog(ex.Message);
            }
            return response;
        }

        public Response<Order> EditOrder(Order order)
        {
            var response = new Response<Order>();
            var orderManager = ManagerFactory.CreateOrderManager();

            try
            {
                order.LaborCost = Math.Round((order.Product.LaborCostPerSquareFoot * order.Area), 2);
                order.MaterialCost = Math.Round((order.Product.CostPerSquareFoot * order.Area), 2);
                order.Tax = Math.Round(((order.LaborCost + order.MaterialCost) * (order.Taxes.TaxRate/100)), 2);
                order.Total = Math.Round((order.LaborCost + order.MaterialCost + order.Tax), 2);
                order.Date = DateToStringConverter.DateToString(DateTime.Parse(order.Date));
                order.CustomerName = order.CustomerName.Replace(",", "^*");
                orderManager.EditFile(order, order.Date);
                response.Success = true;
                response.Data = order;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                WriteErrorToLog(ex.Message);
            }
            order.CustomerName = order.CustomerName.Replace("^*", ",");
            order.Date = DateToStringConverter.FileToString(order.Date);
            return response;
        }

        public Response<Order> DeleteOrder(int orderNum, string date)
        {
            var response = new Response<Order>();
            var orderManager = ManagerFactory.CreateOrderManager();

            try
            {
                date = DateToStringConverter.DateToString(DateTime.Parse(date));
                orderManager.DeleteFile(orderNum, date);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                WriteErrorToLog(ex.Message);
            }

            return response;
        }

        public Order UpdateOrder(Order order)
        {
            order.LaborCost = Math.Round((order.Product.LaborCostPerSquareFoot * order.Area), 2);
            order.MaterialCost = Math.Round((order.Product.CostPerSquareFoot * order.Area), 2);
            order.Tax = Math.Round(((order.LaborCost + order.MaterialCost) * (order.Taxes.TaxRate / 100)), 2);
            order.Total = Math.Round((order.LaborCost + order.MaterialCost + order.Tax), 2);

            return order;
        }

        public static void WriteErrorToLog(string message)
        {
            var orderManager = ManagerFactory.CreateOrderManager();

            orderManager.MessageToLog(message);
        }
    }
}
