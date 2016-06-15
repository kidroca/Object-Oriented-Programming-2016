namespace Telerik.Homeworks.OOP.Principles.Banks.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Individual : Customer
    {
        public const int NoLoanInterestMonths = 3;

        public const int NoMortageInterestMonths = 6;

        public Individual(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public override decimal CalculateLoanInterests(int months, decimal interestRate)
        {
            return base.CalculateInterests(months, interestRate, NoLoanInterestMonths);
        }

        public override decimal CalculateMortageInterests(int months, decimal interestRate)
        {
            return base.CalculateInterests(months, interestRate, NoMortageInterestMonths);
        }
    }
}