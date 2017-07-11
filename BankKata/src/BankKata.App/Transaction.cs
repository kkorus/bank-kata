namespace BankKata.App
{
    public class Transaction
    {
        public string Date { get; }
        public int Amount { get; }

        public Transaction(string date, int amount)
        {
            Date = date;
            Amount = amount;
        }

        protected bool Equals(Transaction other)
        {
            return string.Equals(Date, other.Date) && Amount == other.Amount;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Date != null ? Date.GetHashCode() : 0) * 397) ^ Amount;
            }
        }
    }
}