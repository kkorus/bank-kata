using System.Collections.Generic;

namespace BankKata.App
{
    public class TransactionRepository
    {
        private readonly Clock _clock;
        private readonly List<Transaction> _transactions;

        public TransactionRepository(Clock clock)
        {
            _clock = clock;
            _transactions = new List<Transaction>();
        }

        public virtual void AddDeposit(int amount)
        {
            AddTransaction(amount);
        }

        public virtual void AddWithdrawal(int amount)
        {
            AddTransaction(-amount);
        }

        private void AddTransaction(int amount)
        {
            _transactions.Add(new Transaction(_clock.GetCurrentDateAsString(), amount));
        }

        public virtual IList<Transaction> GetAllTransactions()
        {
            return _transactions.AsReadOnly();
        }
    }
}