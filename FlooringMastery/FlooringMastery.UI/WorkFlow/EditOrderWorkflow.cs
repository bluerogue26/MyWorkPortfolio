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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            CheckForOrder();
        }

        public static void PromptUserForOrderInfo(Order order)
        {
            string input;
            decimal newArea;
            decimal newCost;
            string oldOrder = order.Date;
            int oldOrderNum = order.OrderNumber;
            var ops = new OrderOperations();
            DateTime date = new DateTime();
            var productsManager = ManagerFactory.CreateProductManager();
            var statesManager = ManagerFactory.CreateTaxManager();
            var products = productsManager.ListAll();
            var states = statesManager.ListAll();

            ShowOrderInfo(order);

            input = AlterUserInput("Please enter your company name: ");

            if (input.Trim().Length > 0)
            {
                order.CustomerName = input;
            }
            Console.Clear();
            
            ShowOrderInfo(order);

            do
            {
                input = AlterUserInput("Please enter the area you would like to buy flooring for: ");
                if (decimal.TryParse(input, out newArea))
                {
                    if (newArea <= 0)
                    {
                        Console.WriteLine("Please enter a positive area...");
                        UserInteractions.KeyToContinue();
                    }
                    else
                    {
                        order.Area = newArea;
                        break;
                    }
                }
                else
                {
                    break;   
                }
            } while (true);

            Console.Clear();
            order = ops.UpdateOrder(order);
            ShowOrderInfo(order);

            Console.WriteLine("---------------------------");
            Console.WriteLine("Please choose a material from the list below:");
            foreach (var product in products)
            {
                Console.Write(product.ProductType + "  ");
                Console.WriteLine("Per Square Foot: " + product.CostPerSquareFoot);
            }

            do
            {
                input = AlterUserInput("Enter a product name: ");
                if (input.Trim().Length == 0)
                    break;
                if (productsManager.IsValidProduct(input))
                {
                    order.Product = productsManager.GetSingleProduct(input);
                    do
                    {
                        input = AlterUserInput("Are there any sale prices? Y/N");
                        if (input.ToUpper() == "Y")
                        {
                            do
                            {
                                Console.Clear();
                                order = ops.UpdateOrder(order);
                                ShowOrderInfo(order);
                                input = AlterUserInput("What is the special labor cost?");
                                if (input.Trim().Length == 0)
                                    break;
                                if (decimal.TryParse(input, out newCost))
                                {
                                    order.Product.LaborCostPerSquareFoot = newCost;
                                    break;
                                }
                            } while (true);

                            Console.Clear();
                            order = ops.UpdateOrder(order);
                            ShowOrderInfo(order);

                            do
                            {
                                input = AlterUserInput("What is the special product cost?");
                                if (input.Trim().Length == 0)
                                    break;
                                if (decimal.TryParse(input, out newCost))
                                {
                                    order.Product.CostPerSquareFoot = newCost;
                                    break;
                                }
                            } while (true);
                            break;
                        }
                        if (input.ToUpper() == "N")
                        {
                            break;
                        }
                    } while (true);
                    break;
                }
            } while (true);


            Console.Clear();
            order = ops.UpdateOrder(order);
            ShowOrderInfo(order);

            Console.WriteLine("---------------------------");
            Console.WriteLine("Please choose a state to work within, we work in these states:");
            foreach (var state in states)
            {
                Console.WriteLine(state.StateAbbreviation);
            }
            do
            {
                input = AlterUserInput("Enter a state abbreviation: ");
                if (input.Trim().Length == 0)
                    break;
                if (statesManager.IsValidState(input))
                {
                    order.Taxes = statesManager.GetSingleState(input);
                    break;
                }
            } while (true);

            Console.Clear();
            order = ops.UpdateOrder(order);
            ShowOrderInfo(order);

            do
            {
                input = AlterUserInput("Please enter the new date: ");
                if (input.Trim().Length == 0)
                {
                    break;
                }
                if (DateTime.TryParse(input, out date))
                {
                    order.Date = DateToStringConverter.DateToString(date);
                    break;
                }
                
                Console.WriteLine("Please enter a valid date format. Ex. (06 22 1999)");
            } while (true);

            Console.Clear();

            if (oldOrder == order.Date)
            {
                EditOrder(order);
            }
            else
            {
                AddOrder(order, date);
                DeleteOrder(oldOrder, oldOrderNum);
            }
        }

        public static void AddOrder(Order order, DateTime date)
        {
            var ops = new OrderOperations();
            var confirmation = ops.CreateOrder(order.CustomerName, order.Taxes, order.Product, order.Area, date);
            DisplayOrderConfirmation(confirmation);
        }

        public static void DisplayOrderConfirmation(Response<Order> confirmation)
        {

            Console.Clear();
            if (confirmation.Success)
            {
                Console.WriteLine("Thank you {0}, your order is now altered.", confirmation.Data.CustomerName);
                Console.WriteLine("Your order number is {1} and your order date is now {0}", confirmation.Data.Date, confirmation.Data.OrderNumber);
                Console.WriteLine("You ordered {0} square feet of {1}.", confirmation.Data.Area, confirmation.Data.Product.ProductType);
                Console.WriteLine("Your labor cost is {0:c}, the material cost is {1:c}, \nthe tax is {2:c}, for a total cost of {3:c}.", confirmation.Data.LaborCost, confirmation.Data.MaterialCost, confirmation.Data.Tax, confirmation.Data.Total);
                UserInteractions.KeyToContinue();
            }
            else
            {
                Console.WriteLine("There was a problem creating your new order.");
                Console.WriteLine("The error was {0}", confirmation.Message);
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
                Console.WriteLine("---------------------------");
                UserInteractions.KeyToContinue();
                Console.Clear();
                PromptUserForOrderInfo(response.Data);
            }
            else
            {
                Console.WriteLine(response.Message);
                UserInteractions.KeyToContinue();
            }
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
            Console.WriteLine("If you wish to leave a property unchanged, leave the field blank");
        }

        public static string AlterUserInput(string prompt)
        {
            string input;

            Console.WriteLine("---------------------------");
            Console.WriteLine(prompt);

            input = Console.ReadLine();

            return input;
        }

        public static void EditOrder(Order order)
        {
            var ops = new OrderOperations();
            var confirmation = ops.EditOrder(order);
            DisplayOrderConfirmation(confirmation);
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
