using System.Linq;
using BankKata.App;
using Moq;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private const string Today = "12/05/2015";
        private TransactionRepository _transactionRepository;
        private Mock<Clock> _clock;

        [SetUp]
        public void SetUp()
        {
            _transactionRepository = new TransactionRepository();
            _clock = new Mock<Clock>();
        }

        public Transaction Transaction(string date, int amount)
        {
            return new Transaction(date, amount);
        }

        [Test]
        public void Create_And_Store_A_Transaction()
        {
            // Arrange
            _clock.Setup(x => x.GetCurrentDateAsString()).Returns(Today);

            // Act
            _transactionRepository.AddDeposit(100);

            // Assert
            var transactions = _transactionRepository.GetAllTransactions();
            Assert.That(transactions.Count(), Is.EqualTo(1));
            Assert.That(transactions.First(), Is.EqualTo(Transaction("12/05/2015", 100)));
        }
    }
}