using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGBank.UI.Workflows
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SCG BANK");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Delete Account");
                Console.WriteLine("3. Lookup Account");
                Console.WriteLine("\n(Q)uit");

                Console.Write("\n\nEnter choice: ");
                string input = Console.ReadLine();

                if (input == "Q")
                    break;

                ProcessChoice(input);
            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var createAccountWorkflow = new CreateAccountWorkflow();
                    createAccountWorkflow.Execute();
                    break;
                case "2":
                    var deleteAccountWorkflow = new DeleteAccountWorkflow();
                    deleteAccountWorkflow.Execute();
                    break;
                case"3":
                    var lookupMenu = new LookupMenu();
                    lookupMenu.Execute();
                    break;
            }
        }
    }
}
