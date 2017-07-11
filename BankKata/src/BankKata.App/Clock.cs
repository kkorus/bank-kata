using System;

namespace BankKata.App
{
    public class Clock
    {
        public virtual string GetCurrentDateAsString()
        {
            return GetToday().ToString("dd'/'MM'/'yyyy");
        }

        protected virtual DateTime GetToday()
        {
            return DateTime.UtcNow;
        }
    }
}