using System.Collections.Generic;
using System.Globalization;

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
            PrintHeader();
            PrintStatementLines(transactions);
        }

        private void PrintHeader()
        {
            _console.PrintLine(Header);
        }

        private void PrintStatementLines(IEnumerable<Transaction> transactions)
        {
            var lines = CreateFormattedStatementLines(transactions);
            lines.ForEach(x => _console.PrintLine(x));
        }

        private static List<string> CreateFormattedStatementLines(IEnumerable<Transaction> transactions)
        {
            var runningBalance = 0;
            var lines = new List<string>();

            foreach (var transaction in transactions)
            {
                runningBalance += transaction.Amount;
                var lineStatement =
                    $"{transaction.Date} | {transaction.Amount.ToString("0.00", CultureInfo.InvariantCulture)} | {runningBalance.ToString("0.00", CultureInfo.InvariantCulture)}";
                lines.Add(lineStatement);
            }

            lines.Reverse();
            return lines;
        }
    }
}