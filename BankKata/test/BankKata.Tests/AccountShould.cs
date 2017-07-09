using System.Collections.Generic;
using BankKata.App;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class AccountShould
    {
        private Mock<TransactionRepository> _transactionRepository;
        private Mock<StatementPrinter> _statementPrinter;
        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _statementPrinter = new Mock<StatementPrinter>();
            _transactionRepository = new Mock<TransactionRepository>();
            _account = new Account(_transactionRepository.Object);
        }

        [Test]
        public void Store_A_Desposit_Transaction()
        {
            // Arrange
            const int amount = 100;

            // Act
            _account.Deposit(amount);

            // Assert
            _transactionRepository.Verify(x => x.AddDeposit(amount));
        }

        [Test]
        public void Store_A_Withdrawal_Transaction()
        {
            // Arrange
            const int amount = 100;
            // Act
            _account.Withdraw(amount);

            // Assert
            _transactionRepository.Verify(x => x.AddWithdrawal(amount));
        }

        [Test]
        public void Print_A_Statement()
        {
            // Arrange
            var transactions = new List<Transaction>();
            _transactionRepository.Setup(x => x.GetAllTransactions()).Returns(transactions);

            // Act
            _account.PrintStatement();

            // Assert
            _statementPrinter.Verify(x => x.Print(transactions));
        }
    }
}