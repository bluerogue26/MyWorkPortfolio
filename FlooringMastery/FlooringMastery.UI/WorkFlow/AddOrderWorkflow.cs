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
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            PromptUserForOrderInfo();
        }

        public void PromptUserForOrderInfo()
        {
            string input;
            decimal newArea;
            var ops = new OrderOperations();
            var productsManager = ManagerFactory.CreateProductManager();
            var statesManager = ManagerFactory.CreateTaxManager();
            var order = new Order();
            var products = productsManager.ListAll();
            var states = statesManager.ListAll();


                Console.Clear();
                Console.WriteLine("Add a New Order");
                order.CustomerName = GetUserInput("Please enter your company name: ");
                Console.Clear();

            do
            {
                input = GetUserInput("Please enter the area you would like to buy flooring for: ");
                if (decimal.TryParse(input, out newArea))
                    if (newArea <= 0)
                    {
                        Console.WriteLine("Please enter a positive area...");
                        UserInteractions.KeyToContinue();
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
            } while (true);

            order.Area = newArea;

            Console.Clear();
            Console.WriteLine("Please choose a material from the list below:");
            foreach (var product in products)
            {
                Console.Write(product.ProductType + "  ");
                Console.WriteLine("Per Square Foot: " + product.CostPerSquareFoot);
            }

            do
            {
                input = GetUserInput("Enter a product name: ");
                if (productsManager.IsValidProduct(input))
                {
                    Console.Clear();
                    break;
                }
            } while (true);

            order.Product = productsManager.GetSingleProduct(input);

            Console.WriteLine("Please choose a state to work within, we work in these states:");
            foreach (var state in states)
            {
                Console.WriteLine(state.StateAbbreviation);
            }
            do
            {
                input = GetUserInput("Enter a state abbreviation: ");
                if (statesManager.IsValidState(input))
                {
                    Console.Clear();
                    break;
                }
            } while (true);

            order.Taxes = statesManager.GetSingleState(input);

            DateTime date = DateTime.Now;

            order = ops.UpdateOrder(order);

            DisplayOrder(order);

            do
            {
                input = Console.ReadLine();
                if (input.ToUpper() == "Y")
                {
                    AddOrder(order, date);
                    break;
                }

                if (input.ToUpper() == "N")
                {
                    break;
                }
            } while (true);
        }

        private void DisplayOrder(Order order)
        {
            Console.WriteLine("Order Name: {0}", order.CustomerName);
            Console.WriteLine("Order State: {0}", order.Taxes.StateAbbreviation);
            Console.WriteLine("Order Material: {0}", order.Product.ProductType);
            Console.WriteLine("Order Area: {0}", order.Area);
            Console.WriteLine("Order Labor Cost: {0:c}", order.LaborCost);
            Console.WriteLine("Order Material Cost: {0:c}", order.MaterialCost);
            Console.WriteLine("Order Tax: {0:c}", order.Tax);
            Console.WriteLine("Order Total: {0:c}", order.Total);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Would you like to commit this order? Y/N");
        }

        public void AddOrder(Order order, DateTime date)
        {
            var ops = new OrderOperations();
            var confirmation = ops.CreateOrder(order.CustomerName, order.Taxes, order.Product, order.Area, date);
            DisplayAddOrderConfirmation(confirmation);
        }

        public void DisplayAddOrderConfirmation(Response<Order> confirmation)
        {

            Console.Clear();
            if (confirmation.Success)
            {
                Console.WriteLine("Thank you for creating a new order, {0}!", confirmation.Data.CustomerName);
                Console.WriteLine("Your new account number is {0} and was created on {1}", confirmation.Data.OrderNumber, confirmation.Data.Date);
                Console.WriteLine("You ordered {0} square feet of {1}.", confirmation.Data.Area, confirmation.Data.Product.ProductType);
                Console.WriteLine("Your labor cost is {0:c}, the tax is {1:c}, for a total cost of {2:c}.", confirmation.Data.LaborCost, confirmation.Data.Tax, confirmation.Data.Total);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There was a problem creating your new order.");
                Console.WriteLine("The error was {0}", confirmation.Message);
                Console.ReadKey();
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
    }
}
