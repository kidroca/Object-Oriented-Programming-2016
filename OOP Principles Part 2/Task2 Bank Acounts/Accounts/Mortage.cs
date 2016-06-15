namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using Balances;
    using Customers;

    public class Mortage : Account
    {
        public Mortage(Customer customer, Balance initialBalance)
            : base(customer, initialBalance)
        {
        }

        public override decimal GetInterenstAmountFor(int months)
        {
            return this.Customer.CalculateMortageInterests(months, this.InterestRate);
        }

        public override void MakeDeposit(decimal amount)
        {
            this.Balance.Funds += amount;
        }
    }
}