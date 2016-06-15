namespace Telerik.Homeworks.OOP.Principles.Banks.Accounts
{
    using System;
    using System.Text;
    using Balances;
    using Customers;
    
    public class Loan : Account
    {
        public Loan(Customer customer, Balance initialBallance)
            : base(customer, initialBallance)
        {
        }

        public override decimal GetInterenstAmountFor(int months)
        {
            return this.Customer.CalculateLoanInterests(months, this.InterestRate);
        }

        public override void MakeDeposit(decimal amount)
        {
            this.Balance.Funds += amount;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            string newLine = "\n";

            strBuilder.Append("Account Type: Loan");
            strBuilder.Append(newLine);
            strBuilder.Append(base.ToString());
            strBuilder.Append(newLine);
            strBuilder.AppendFormat("Remaining Loan: {0}", Math.Abs(this.Balance.Funds));

            return strBuilder.ToString();
        }
    }
}