namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts.Balances
{
    public class Balance
    {
        private decimal funds;

        private TransactionHistory transactionHistory;

        public Balance()
        {
            this.transactionHistory = new TransactionHistory();
        }

        public Balance(decimal initialFunds)
            : this()
        {
            this.Funds = initialFunds;
        }

        public decimal Funds
        {
            get
            {
                return this.funds;
            }

            set
            {
                decimal amount = value - this.funds;

                this.funds = value;

                this.transactionHistory.Add(amount);
            }
        }
    }
}