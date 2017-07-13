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
            _clock.SetupSequence(x => x.GetCurrentDateAsString())
                .Returns("01/04/2014")
                .Returns("02/04/2014")
                .Returns("10/04/2014");

            _account.Deposit(1000);
            _account.Withdraw(100);
            _account.Deposit(500);

            // Act
            _account.PrintStatement();

            // Assert
            _console.Setup(_ => _.PrintLine("DATE | AMOUNT | BALANCE"));
            _console.Verify(_ => _.PrintLine("10/04/2014 | 500.00 | 1400.00"));
            _console.Verify(_ => _.PrintLine("02/04/2014 | -100.00 | 900.00"));
            _console.Verify(_ => _.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }
    }
}