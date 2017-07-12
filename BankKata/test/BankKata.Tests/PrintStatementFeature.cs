using BankKata.App;
using Moq;
using Moq.Sequences;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private Mock<Console> _console;
        private Account _account;
        private Mock<Clock> _clock;

        [SetUp]
        public void SetUp()
        {
            _console = new Mock<Console>();
            _clock = new Mock<Clock>();

            var transactionRepository = new TransactionRepository(_clock.Object);
            var statementPrinder = new StatementPrinter(_console.Object);
            _account = new Account(transactionRepository, statementPrinder);
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
            using (Sequence.Create())
            {
                _console.Setup(_ => _.PrintLine("DATE | AMOUNT | BALANCE")).InSequence();
            }
        }
    }
}