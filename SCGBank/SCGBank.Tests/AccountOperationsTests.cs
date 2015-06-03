using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SCGBank.BLL;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.Tests
{
    [TestFixture]
    public class AccountOperationsTests
    {
        [Test]
        public void NotFoundAccountReturnsFail()
        {
            var manager = new AccountOperations();

            var response = manager.GetAccount(105);

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void FoundAccountReturnsSuccess()
        {
            var manager = new AccountOperations();

            var response = manager.GetAccount(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.AccountNumber);
            Assert.AreEqual("Mary", response.Data.FirstName);
            Assert.AreEqual("Jones", response.Data.LastName);
            Assert.AreEqual(347.00M, response.Data.Balance);
        }

        [Test]
        public void CanDepositMoney()
        {
            var manager = new AccountOperations();

            var accountLoadResponse = manager.GetAccount(1);
            var depositResponse = manager.Deposit(accountLoadResponse.Data, 50.00M);

            Assert.IsTrue(depositResponse.Success);

            var reloadAccountResponse = manager.GetAccount(1);

            Assert.AreEqual(1, reloadAccountResponse.Data.AccountNumber);
            Assert.AreEqual("Mary", reloadAccountResponse.Data.FirstName);
            Assert.AreEqual("Jones", reloadAccountResponse.Data.LastName);
            Assert.AreEqual(397.00M, reloadAccountResponse.Data.Balance);
        }

        [Test]
        public void RejectDepositNegativeMoney()
        {
            var manager = new AccountOperations();

            var accountLoadResponse = manager.GetAccount(1);
            var depositResponse = manager.Deposit(accountLoadResponse.Data, -50.00M);

            Assert.IsFalse(depositResponse.Success);
        }

        [Test]
        public void CanOpenAccount()
        {
            var manager = new AccountOperations();

            var account = new Account
            {
                AccountNumber = 0,
                FirstName = "Joe",
                LastName = "Smith",
                Balance = 10.00M
            };

            var response = manager.OpenAccount(account);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(5, response.Data.AccountNumber);
            Assert.AreEqual("Joe", response.Data.FirstName);
            Assert.AreEqual("Smith", response.Data.LastName);
            Assert.AreEqual(10.00M, response.Data.Balance);
        }

        [Test]
        public void RejectAccountWithNoBalance()
        {
            
        }

        [Test]
        public void RejectAccountWithNoName()
        {
            
        }

        [Test]
        public void WithdrawSucess()
        {
            var manager = new AccountOperations();

            var accountLoadResponse = manager.GetAccount(1);
            var withdrawResponse = manager.Withdraw(accountLoadResponse.Data, 50.00M);

            Assert.IsTrue(withdrawResponse.Success);

            var reloadAccountResponse = manager.GetAccount(1);

            Assert.AreEqual(1, reloadAccountResponse.Data.AccountNumber);
            Assert.AreEqual("Mary", reloadAccountResponse.Data.FirstName);
            Assert.AreEqual("Jones", reloadAccountResponse.Data.LastName);
            Assert.AreEqual(297.00M, reloadAccountResponse.Data.Balance);
        }

        [Test]
        public void RejectWithdrawNegativeMoney()
        {
            var manager = new AccountOperations();

            var accountLoadResponse = manager.GetAccount(1);
            var withdrawResponse = manager.Withdraw(accountLoadResponse.Data, -50.00M);

            Assert.IsFalse(withdrawResponse.Success);
        }

        [Test]
        public void TransferSucess()
        {
            var manager = new AccountOperations();

            var accountDeposit = manager.GetAccount(1);
            var accountWithdraw = manager.GetAccount(2);

            var transferResponse = manager.Transfer(accountDeposit.Data, accountWithdraw.Data, 50.00M);

            Assert.IsTrue(transferResponse.Success);

            var reloadAccountResponse = manager.GetAccount(1);

            Assert.AreEqual(1, reloadAccountResponse.Data.AccountNumber);
            Assert.AreEqual("Mary", reloadAccountResponse.Data.FirstName);
            Assert.AreEqual("Jones", reloadAccountResponse.Data.LastName);
            Assert.AreEqual(397.00M, reloadAccountResponse.Data.Balance);

            var checkSecondAccount = manager.GetAccount(2);

            Assert.AreEqual(2, checkSecondAccount.Data.AccountNumber);
            Assert.AreEqual("Bob", checkSecondAccount.Data.FirstName);
            Assert.AreEqual("Elk", checkSecondAccount.Data.LastName);
            Assert.AreEqual(73.00M, checkSecondAccount.Data.Balance);
        }

        [Test]
        public void TransferFail()
        {
            var manager = new AccountOperations();

            var accountDeposit = manager.GetAccount(1);
            var accountWithdraw = manager.GetAccount(2);

            var transferResponse = manager.Transfer(accountDeposit.Data, accountWithdraw.Data, 500.00M);

            Assert.IsFalse(transferResponse.Success);
        }
    }
}
