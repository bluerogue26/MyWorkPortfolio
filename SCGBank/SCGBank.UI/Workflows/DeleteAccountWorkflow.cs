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
    public class DeleteAccountWorkflow
    {
        private Account _currentAccount;
   
        public void Execute()
        {
            int accountNumber = GetAccountNumberFromUser();

            DisplayAccountInformation(accountNumber);

            Console.Write("If you would like to delete this account, type YES :");
            string input = Console.ReadLine();
            if (input == "YES")
            {
                var ops = new AccountOperations();
                var response = ops.DeleteAccount(_currentAccount);

                Console.WriteLine(response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        private void DisplayAccountInformation(int accountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(accountNumber);
            Console.Clear();

            if (response.Success)
            {
                _currentAccount = response.Data;
                PrintAccountDetails(response);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("A problem occurred...");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public int GetAccountNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter an account number: ");
                string input = Console.ReadLine();
                int accountNumber;

                if (int.TryParse(input, out accountNumber))
                    return accountNumber;

                Console.WriteLine("That was not a valid account number.  Press any key to continue...");
                Console.ReadKey();
            } while (true);
        }

        private void PrintAccountDetails(Response<Account> response)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("=======================================");
            Console.WriteLine("Account Number: {0}", response.Data.AccountNumber);
            Console.WriteLine("Account Name: {0} {1}", response.Data.FirstName, response.Data.LastName);
            Console.WriteLine("Account Balance: {0:c}", response.Data.Balance);
        }
    }
}