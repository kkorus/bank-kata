namespace BankKata.App
{
    public class Account
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly StatementPrinter _printterStatemnt;

        public Account(
            TransactionRepository transactionRepository,
            StatementPrinter printterStatemnt)
        {
            _transactionRepository = transactionRepository;
            _printterStatemnt = printterStatemnt;
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
            var transactions = _transactionRepository.GetAllTransactions();
            _printterStatemnt.Print(transactions);
        }
    }
}