﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.BLL;
using SCGBank.Models;
using SCGBank.UI.Utilities;

namespace SCGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetWithdrawAmount();
            var accountOps = new AccountOperations();

            var response = accountOps.Withdraw(account, amount);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Withdrew from Account {0}, New Balance: {1:c}", response.Data.AccountNumber, response.Data.NewBalance);
                UserInteractions.KeyToContinue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An error occurred: {0}", response.Message);
                UserInteractions.KeyToContinue();
            }
        }

        private decimal GetWithdrawAmount()
        {
            do
            {
                Console.Write("Enter a positive amount to withdraw: ");
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