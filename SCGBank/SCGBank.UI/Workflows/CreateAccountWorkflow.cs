using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.BLL;
using SCGBank.Models;
using SCGBank.UI.Utilities;

namespace SCGBank.UI.Workflows
{
    public class CreateAccountWorkflow
    {
        public void Execute()
        {
            PromptUserForAccountInfo();
        }

        private void PromptUserForAccountInfo()
        {
            var account = new Account();

            string intputBalance;
            decimal startingBalance;

            account.FirstName = GetUserInput("Please enter your first name: ");
            account.LastName = GetUserInput("Please enter your last name: ");
            do
            {
                intputBalance = GetUserInput("Please enter your starting balance: ");
                if (decimal.TryParse(intputBalance, out startingBalance))
                    break;
            } while (true);
            account.Balance = startingBalance;

            CreateAccount(account);
        }

        private void CreateAccount(Account account)
        {
            var ops = new AccountOperations();
            var confirmation = ops.OpenAccount(account);
            DisplayAccountCreationConfirmation(confirmation);
        }

        private void DisplayAccountCreationConfirmation(Response<Account> confirmation)
        {
            Console.Clear();
            if (confirmation.Success)
            {
                Console.WriteLine("Thank you for opening a new account.");
                Console.WriteLine("Your new account number is {0} and you have an opening balance of {1:c}", confirmation.Data.AccountNumber, confirmation.Data.Balance);
                UserInteractions.KeyToContinue();
            }
            else
            {
                Console.WriteLine("There was a problem opening your new account.");
                Console.WriteLine("The error was {0}", confirmation.Message);
                UserInteractions.KeyToContinue();
            }
            
        }

        private static string GetUserInput(string prompt)
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("Create A New Account");
                Console.WriteLine("------------------------------------------------");
                Console.Write(prompt);
                input = Console.ReadLine();

                if (input.Trim().Length > 0)
                    break;
            } while (true);
            return input;
        }

        
    }
}
