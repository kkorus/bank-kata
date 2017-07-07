using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankKata.App;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private Mock<Console> _console;

        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _console = new Mock<Console>();
            _account = new Account();
        }

        [TearDown]
        public void TearDown()
        {
            _console.Reset();
        }

        [Test]
        public void PrintStatement_Contains_AllTransactions()
        {
            // Arrange
            _account.Deposit(1000);
            _account.Withdraw(100);
            _account.Deposit(500);

            // Act
            _account.PrintStatement();

            // Assert
            _console.Verify(x => x.PrintLine("DATE | AMOUNT | BALANCE"));

        }
    }
}
