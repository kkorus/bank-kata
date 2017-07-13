using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using BankKata.App;

namespace BankKata.Tests
{
    public class StatementPrinterShould
    {
        private Mock<Console> _console;
        private StatementPrinter _statementPrinter;

        private static readonly IEnumerable<Transaction> NoTransactions = Enumerable.Empty<Transaction>();

        [SetUp]
        public void SetUp()
        {
            _console = new Mock<Console>();
            _statementPrinter = new StatementPrinter(_console.Object);
        }

        [Test]
        public void Always_Print_The_Header()
        {
            // Arrange

            // Act
            _statementPrinter.Print(NoTransactions);

            // Assert
            _console.Verify(x => x.PrintLine("DATE | AMOUNT | BALANCE"));
        }

        [Test]
        public void Print_Transactions_In_Reverse_Chronological_Order()
        {
            // Arrange
            var transactions = TransactionsContaing(
                Deposit("01/04/2014", 1000),
                Withdrawal("02/04/2014", 100),
                Deposit("10/04/2014", 500));

            // Act
            _statementPrinter.Print(transactions);

            // Assert
            _console.Verify(_ => _.PrintLine("DATE | AMOUNT | BALANCE"));
            _console.Verify(_ => _.PrintLine("10/04/2014 | 500.00 | 1400.00"));
            _console.Verify(_ => _.PrintLine("02/04/2014 | -100.00 | 900.00"));
            _console.Verify(_ => _.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }

        private IEnumerable<Transaction> TransactionsContaing(params Transaction[] transactions)
        {
            return transactions;
        }

        private Transaction Deposit(string date, int amount)
        {
            return new Transaction(date, amount);
        }

        private Transaction Withdrawal(string date, int amount)
        {
            return new Transaction(date, -amount);
        }
    }
}
