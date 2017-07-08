using BankKata.App;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class AccountShould
    {
        private Mock<TransactionRepository> _transactionRepository;
        private Account _account;

        [SetUp]
        public void SetUp()
        {
            _transactionRepository = new Mock<TransactionRepository>();
            _account = new Account(_transactionRepository.Object);
        }

        [Test]
        public void Store_A_Desposit_Transaction()
        {
            // Act
            _account.Deposit(100);

            // Assert
            _transactionRepository.Verify(x => x.AddDeposit(100));
        }

        [Test]
        public void Store_A_Withdrawal_Transaction()
        {
            // Act
            _account.Withdraw(100);

            // Assert
            _transactionRepository.Verify(x => x.AddWithdrawal(100));
        }
    }
}