using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.BLL
{
    public class AccountOperations
    {
        public Response<Account> GetAccount(int accountNumber)
        {
            var repo = new AccountRepository();
            var response = new Response<Account>();

            try
            {
                var account = repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    response.Success = false;
                    response.Message = "Account not found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = account;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public Response<Account> OpenAccount(Account accountToOpen)
        {
            var response = new Response<Account>();
            

            try
            {
                if (accountToOpen.Balance <= 0)
                {
                    response.Success = false;
                    response.Message = "Must provide a positive balance to open an account.";
                }
                else if ((accountToOpen.FirstName.Trim().Length == 0) || (accountToOpen.LastName.Trim().Length == 0))
                {
                    response.Success = false;
                    response.Message = "Must provide both a first and a last name to open an account";
                }
                else
                {
                    var repo = new AccountRepository();
                    var allAccounts = repo.GetAllAcounts();

                    var accountNumber = allAccounts.Max(a => a.AccountNumber);
                    accountNumber++;

                    accountToOpen.AccountNumber = accountNumber;

                    repo.AddAccount(accountToOpen);

                    response.Success = true;
                    response.Data = accountToOpen;
                }
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public Response<DepositReceipt> Deposit(Account account, decimal amount)
        {
            var response = new Response<DepositReceipt>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Can not deposit a negative amount";
                }
                else
                {
                    account.Balance += amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new DepositReceipt();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<DepositReceipt> Withdraw(Account account, decimal amount)
        {
            var response = new Response<DepositReceipt>();

            try
            {
                if (amount > account.Balance)
                {
                    response.Success = false;
                    response.Message = "Not enough money!";
                }
                else if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Withdraw a positive amount of money bitte!";
                }
                else
                {
                    account.Balance -= amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);
                    response.Success = true;

                    response.Data = new DepositReceipt();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response<TransferReceipt> Transfer(Account deposit, Account withdraw, decimal amount)
        {
            var response = new Response<TransferReceipt>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "You can only transfer a positive amount!";
                }
                else if (amount > withdraw.Balance)
                {
                    response.Success = false;
                    response.Message = "The first account doesn't have enough funds!";
                }
                else
                {
                    deposit.Balance += amount;
                    withdraw.Balance -= amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(deposit);
                    repo.UpdateAccount(withdraw);
                    response.Success = true;

                    response.Data = new TransferReceipt();
                    response.Data.WithdrawAccount = withdraw.AccountNumber;
                    response.Data.DepositAccount = deposit.AccountNumber;
                    response.Data.DepositBalance = deposit.Balance;
                    response.Data.WithdrawBalance = withdraw.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<Account> DeleteAccount(Account accountToDelete)
        {
            var repo = new AccountRepository();

            var response = new Response<Account>();
            try
            {
                repo.DeleteAccount(accountToDelete);
                response.Success = true;
                response.Message = "Thank you for banking with us!";
                response.Data = accountToDelete;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
