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
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            GetDateFromUser();
        }

        public static void GetDateFromUser()
        {
            string input;
            var ops = new OrderOperations();
            DateTime date = new DateTime();
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

            var response = ops.LoadAllOrders(date);

            if (response.Success)
            {
                DisplayListOfOrders(response.Data, date);
            }
            else
            {
                Console.WriteLine(response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        public static void DisplayListOfOrders(List<Order> orderList, DateTime date)
        {
            string dateString = DateToStringConverter.FileToString(DateToStringConverter.DateToString(date));
            Console.WriteLine("All orders from {0} ", dateString);
            Console.WriteLine("-----------------------------------");
            foreach (var order in orderList)
            {
                Console.WriteLine("Order Number: {0}, Order Name: {1}", order.OrderNumber, order.CustomerName);
                Console.WriteLine("{0} Square Feet of {1} in {2}", order.Area, order.Product.ProductType, order.Taxes.StateAbbreviation);
                Console.WriteLine("Total Cost: {0:c}\n", order.Total);
            }
            UserInteractions.KeyToContinue();
        }

        public static string GetUserInput(string prompt)
        {
            string input;

            do
            {
                Console.WriteLine(prompt);

                input = Console.ReadLine();
                if (input.Trim().Length > 0)
                    break;
            } while (true);

            return input;
        }
    }
}
