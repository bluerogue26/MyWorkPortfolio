using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCGBank.Models;

namespace SCGBank.Data
{
    public class AccountRepository
    {
        private const string FilePath = @"DataFiles\Bank.txt";

        public Account LoadAccount(int accountNumber)
        {
            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();

                account.AccountNumber = int.Parse(columns[0]);
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                if (account.AccountNumber == accountNumber)
                    return account;
            }

            return null;
        }

        public List<Account> GetAllAcounts()
        {
            List<Account> accounts = new List<Account>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();

                account.AccountNumber = int.Parse(columns[0]);
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                accounts.Add(account);
            }

            return accounts;
        }

        public void AddAccount(Account accountToAdd)
        {
            var accounts = GetAllAcounts();

            accounts.Add(accountToAdd);

            OverWriteFile(accounts);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var accounts = GetAllAcounts();

            var existingAccount = accounts.First(a => a.AccountNumber == accountToUpdate.AccountNumber);
            existingAccount.Balance = accountToUpdate.Balance;

            OverWriteFile(accounts);
        }

        private void OverWriteFile(List<Account> accounts)
        {
            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("AccountNumber,FirstName,LastName,Balance");

                foreach (var account in accounts)
                {
                    writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.FirstName, account.LastName, account.Balance);
                }
            }
        }

        public void DeleteAccount(Account accountToDelete)
        {
            var accounts = GetAllAcounts();

            accounts.Remove(accounts.First(a => a.AccountNumber == accountToDelete.AccountNumber));

            OverWriteFile(accounts);
        }
    }
}
