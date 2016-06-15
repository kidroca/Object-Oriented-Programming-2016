namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts.Balances
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TransactionHistory : IEnumerable<decimal>
    {
        private Dictionary<DateTime, decimal> history = new Dictionary<DateTime, decimal>();

        public TransactionHistory()
        {
        }

        public decimal this[DateTime date]
        {
            get
            {
                if (this.history.ContainsKey(date))
                {
                    return this.history[date];
                }
                else
                {
                    throw new ArgumentException("No history on the given date");
                }
            }
        }

        public void Add(decimal amount, DateTime date = new DateTime())
        {
            this.history[date] = amount;
        }

        public List<DateTime> GetDates()
        {
            return this.history
                    .Keys
                    .ToList();
        }

        public int Length
        {
            get
            {
                return this.history.Count;
            }
        }

        public IEnumerator<decimal> GetEnumerator()
        {
            return this.history.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.history.Values.GetEnumerator();
        }
    }
}