using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.WorkFlow
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to SWC Flooring Company!");
                Console.WriteLine("********************************");
                Console.WriteLine("Enter your choice from the menu: ");
                Console.WriteLine("1 - Display Order");
                Console.WriteLine("2 - Add an Order");
                Console.WriteLine("3 - Edit an Order");
                Console.WriteLine("4 - Remove an Order");
                Console.WriteLine("(Q)uit");

                string input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                    break;

                ProcessInput(input);
            } while (true);
        }



        public void ProcessInput(string input)
        {
            switch (input)
            {
                case "1":
                    var displayOrderWorkflow = new DisplayOrderWorkflow();
                    displayOrderWorkflow.Execute();
                    break;
                case "2":
                    var addOrderWorkflow = new AddOrderWorkflow();
                    addOrderWorkflow.Execute();
                    break;
                case "3":
                    var editOrderWorkflow = new EditOrderWorkflow();
                    editOrderWorkflow.Execute();
                    break;
                case "4":
                    var removeOrderWorkflow = new RemoveOrderWorkflow();
                    removeOrderWorkflow.Execute();
                    break;
            }
        }
    }
}
