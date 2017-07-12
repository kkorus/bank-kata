using System.Collections.Generic;

namespace BankKata.App
{
    public class StatementPrinter
    {
        private readonly Console _console;

        private const string Header = "DATE | AMOUNT | BALANCE";

        public StatementPrinter(Console console)
        {
            _console = console;
        }

        public virtual void Print(IEnumerable<Transaction> transactions)
        {
            _console.PrintLine(Header);
        }
    }
}