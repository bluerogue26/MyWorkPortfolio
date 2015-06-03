using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.UI.Utilities;

namespace FlooringMastery.UI.WorkFlow
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            CheckForOrder();
        }

        public static void CheckForOrder()
        {
            int orderNum;
            string input;
            var ops = new OrderOperations();
            DateTime date = new DateTime();
            Console.Clear();
            do
            {
                input = GetUserInput("Please enter your Order Number: ");
                if (int.TryParse(input, out orderNum))
                    if (orderNum <= 0)
                    {
                        Console.WriteLine("Please enter a positive number...");
                        UserInteractions.KeyToContinue();
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
            } while (true);

            do
            {
                input = GetUserInput("Please enter the date your order was placed");
                if (DateTime.TryParse(input, out date))
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine("Please enter a valid date format. Ex. (06/22/1999)");
            } while (true);

            var response = ops.LoadOrder(orderNum, date);

            if (response.Success)
            {
                ShowOrderInfo(response.Data);
                do
                {
                    input = GetUserInput("Would you like to delete this order? Y/N");
                    if (input.ToUpper() == "Y")
                    {
                        DeleteOrder(response.Data.Date, response.Data.OrderNumber);
                        Console.Clear();
                        Console.WriteLine("Your order has been deleted!");
                        UserInteractions.KeyToContinue();
                    }
                    else if (input.ToUpper() == "N")
                    {
                        break;
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine(response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        public static string GetUserInput(string prompt)
        {
            string input;

            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(prompt);

                input = Console.ReadLine();
                if (input.Trim().Length > 0)
                    break;
            } while (true);

            return input;
        }

        public static void ShowOrderInfo(Order order)
        {
            Console.WriteLine("Order Name: {0}", order.CustomerName);
            Console.WriteLine("Date Ordered: {0}", order.Date);
            Console.WriteLine("Order State: {0}", order.Taxes.StateAbbreviation);
            Console.WriteLine("Order Material: {0}", order.Product.ProductType);
            Console.WriteLine("Order Area: {0}", order.Area);
            Console.WriteLine("Order Labor Cost: {0:c}", order.LaborCost);
            Console.WriteLine("Order Material Cost: {0:c}", order.MaterialCost);
            Console.WriteLine("Order Tax: {0:c}", order.Tax);
            Console.WriteLine("Order Total: {0:c}", order.Total);
        }

        public static void DeleteOrder(String date, int orderNum)
        {
            var ops = new OrderOperations();
            var confirmation = ops.DeleteOrder(orderNum, date);
            if (confirmation.Success == false)
            {
                Console.WriteLine("An error occured when deleting your old order");
                Console.WriteLine("The error was {0}", confirmation.Message);
                UserInteractions.KeyToContinue();
            }
        }
    }
}
