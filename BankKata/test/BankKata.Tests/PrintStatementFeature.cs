using BankKata.App;
using Moq;
using Moq.Sequences;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        [SetUp]
        public void SetUp()
        {
            _console = new Mock<Console>();

            var transactionRepository = new TransactionRepository();
            var statementPrinder = new StatementPrinter();
            _account = new Account(transactionRepository, statementPrinder);
        }

        [TearDown]
        public void TearDown()
        {
            _console.Reset();
        }

        private Mock<Console> _console;

        private Account _account;

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
            using (Sequence.Create())
            {
                _console.Setup(_ => _.PrintLine("DATE | AMOUNT | BALANCE")).InSequence();
            }
        }
    }
}