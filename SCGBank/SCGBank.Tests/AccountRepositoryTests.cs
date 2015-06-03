using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SCGBank.Data;
using SCGBank.Models;

namespace SCGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAccount()
        {
            var repo = new AccountRepository();

            var account = repo.LoadAccount(1);

            Assert.AreEqual(1, account.AccountNumber);
            Assert.AreEqual("Mary", account.FirstName);
            Assert.AreEqual("Jones", account.LastName);
            Assert.AreEqual(347.00M, account.Balance);
        }

        [Test]
        public void CanAddAccount()
        {
            var repo = new AccountRepository();

            var account = new Account
            {
                AccountNumber = 999,
                Balance = 2000.00M,
                FirstName = "John",
                LastName = "Willis"
            };

            repo.AddAccount(account);

            var result = repo.LoadAccount(999);

            Assert.AreEqual(999, result.AccountNumber);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Willis", result.LastName);
            Assert.AreEqual(2000.00M, result.Balance);
        }

        [Test]
        public void CanDeleteAccount()
        {
            var repo = new AccountRepository();

            var account = repo.LoadAccount(1);

            repo.DeleteAccount(account);

            var list = repo.GetAllAcounts();

            Assert.AreEqual(3, list.Count);
        }
    }
}
