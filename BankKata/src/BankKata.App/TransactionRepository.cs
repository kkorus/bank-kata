using System;
using System.Collections.Generic;

namespace BankKata.App
{
    public class TransactionRepository
    {
        public virtual void AddDeposit(int amount)
        {
            throw new NotImplementedException();
        }

        public virtual void AddWithdrawal(int amount)
        {
            throw new NotImplementedException();
        }

        public virtual IList<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }
    }
}