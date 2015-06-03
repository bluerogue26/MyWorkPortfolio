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
    public class TransferWorkflow
    {
        public void Execute(Account firstAccount, Account secondAccount)
        {
            Account deposit = new Account();
            Account withdraw = new Account();
            decimal amount = GetTransferAmount();
            var accountOps = new AccountOperations();
            bool inputCheck = false;
            Console.Clear();
            Console.WriteLine("Are you depositing money into the second account, or withdrawing from it?\n");
            do
            {
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("\n(Q)uit");

                Console.Write("\n\nEnter choice: ");
                string input = Console.ReadLine();

                if (input == "Q")
                    break;
                else if (input == "1")
                {
                    deposit = secondAccount;
                    withdraw = firstAccount;
                    inputCheck = true;
                }
                else if (input == "2")
                {
                    deposit = firstAccount;
                    withdraw = secondAccount;
                    inputCheck = true;
                }
            } while (inputCheck == false);

            var response = accountOps.Transfer(deposit, withdraw, amount);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Deposited to Account {0}, New Balance: {1:c}", response.Data.DepositAccount, response.Data.DepositBalance);
                Console.WriteLine("Withdrew from Account {0}, New Balance: {1:c}", response.Data.WithdrawAccount, response.Data.WithdrawBalance);
                UserInteractions.KeyToContinue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An error occurred: {0}", response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        private decimal GetTransferAmount()
        {
            do
            {
                Console.Write("Enter a positive amount to transfer: ");
                var input = Console.ReadLine();
                decimal amount;

                if (decimal.TryParse(input, out amount))
                    return amount;

                Console.WriteLine("That was not a valid amount.  Please enter in ##.## format");
                UserInteractions.KeyToContinue();
            } while (true);
        }
    }
}