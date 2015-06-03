using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.BLL;
using SCGBank.Models;

namespace SCGBank.UI.Workflows
{
    public class LookupMenu
    {
        private Account _currentAccount;

        public void Execute()
        {
            int accountNumber = GetAccountNumberFromUser();

            DisplayAccountInformation(accountNumber);
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
                DisplayLookupMenu();

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

        private void DisplayLookupMenu()
        {
            do
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("\n(Q)uit");

                Console.Write("\n\nEnter choice: ");
                string input = Console.ReadLine();

                if (input == "Q")
                    break;

                ProcessChoice(input);
            } while (true);
        }

        private void ProcessChoice(string input)
        {
            switch (input)
            {
                case "1":
                    var depositFlow = new DepositWorkflow();
                    depositFlow.Execute(_currentAccount);
                    break;
                case "2":
                    var withdrawFlow = new WithdrawWorkflow();
                    withdrawFlow.Execute(_currentAccount);
                    break;
                case "3":
                    var transferFlow = new TransferWorkflow();
                    var ops = new AccountOperations();
                    int secondNum = GetAccountNumberFromUser();
                    var account = ops.GetAccount(secondNum);
                    PrintAccountDetails(account);
                    var secondAccount = account.Data;

                    transferFlow.Execute(_currentAccount, secondAccount);
                    break;
            }
        }

        private void PrintAccountDetails(Response<Account> response)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("=======================================");
            Console.WriteLine("Account Number: {0}", response.Data.AccountNumber);
            Console.WriteLine("Account Name: {0} {1}", response.Data.FirstName, response.Data.LastName);
            Console.WriteLine("Account Balance: {0:c}", response.Data.Balance);
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
    }
}
