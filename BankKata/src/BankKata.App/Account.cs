namespace BankKata.App
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;

        public Account(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionRepository.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
        }
    }
}