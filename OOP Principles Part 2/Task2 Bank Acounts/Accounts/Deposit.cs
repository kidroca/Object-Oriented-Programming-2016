namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using System;
    using Balances;
    using Customers;

    public class Deposit : Account
    {
        public Deposit(Customer customer, Balance initialBallance)
            : base(customer, initialBallance)
        {
        }

        public override decimal GetInterenstAmountFor(int months)
        {
            if (this.Balance.Funds < 1000)
            {
                return 0;
            }
            else
            {
                return months * this.InterestRate;
            }
        }

        public override void MakeDeposit(decimal amount)
        {
            base.MakeDeposit(amount);

            this.Balance.Funds += amount;
        }

        public override void MakeWithdraw(decimal amount)
        {
            base.MakeWithdraw(amount);

            if (amount > this.Balance.Funds)
            {
                throw new ApplicationException("Trying to withdraw more money than the existing ballance's funds");
            }

            this.Balance.Funds -= amount;
        }
    }
}