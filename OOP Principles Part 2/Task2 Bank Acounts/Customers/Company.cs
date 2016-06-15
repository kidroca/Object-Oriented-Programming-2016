using System;

namespace Telerik.Homeworks.OOP.Principles.Banks.Customers
{
    public class Company : Customer
    {
        public const decimal MortageInterestDecrease = 0.5m;

        public const int MortageInteresetDecreaseDuration = 12;

        public const int NoLoanInterestMonths = 2;

        public Company(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public override decimal CalculateLoanInterests(int months, decimal interestRate)
        {
            return base.CalculateInterests(months, interestRate, NoLoanInterestMonths);
        }

        public override decimal CalculateMortageInterests(int months, decimal interestRate)
        {
            decimal reducedInterest = interestRate * MortageInterestDecrease;

            if (months <= MortageInteresetDecreaseDuration)
            {
                return base.CalculateInterests(months, reducedInterest);
            }
            else
            {
                decimal interests = base.CalculateInterests(MortageInteresetDecreaseDuration, reducedInterest, 0);
                int remainingMonths = months - MortageInteresetDecreaseDuration;

                interests += base.CalculateInterests(remainingMonths, interestRate);

                return interests;
            }
        }
    }
}