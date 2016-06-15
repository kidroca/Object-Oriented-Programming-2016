namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using System;
    using Balances;
    using Customers;

    public abstract class Account
    {
        public Account(Customer customer, Balance initialBallance)
        {
            this.Customer = customer;
            this.Balance = initialBallance;
        }

        public Customer Customer { get; protected set; }

        public int InterestRate { get; protected set; }

        public Balance Balance { get; protected set; }

        public override string ToString()
        {
            return string.Format(
                "Holder: {0}\n Interest Rate: {1}",
                this.Customer.FirstName + ' ' + this.Customer.LastName,
                this.InterestRate);
        }

        public virtual void MakeDeposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ApplicationException("This method only works with positive values above zero");
            }
        }

        public virtual void MakeWithdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ApplicationException("This method only works with positive values above zero");
            }
        }

        public abstract decimal GetInterenstAmountFor(int months);
    }
}