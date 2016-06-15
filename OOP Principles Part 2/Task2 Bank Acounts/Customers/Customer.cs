namespace Telerik.Homeworks.OOP.Principles.Banks.Customers
{
    public abstract class Customer
    {
        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public override string ToString()
        {
            return string.Format("Customer:\nFirst Name: {0} \nLast Name: {1}", this.FirstName, this.LastName);
        }

        public abstract decimal CalculateLoanInterests(int months, decimal interestRate);

        public abstract decimal CalculateMortageInterests(int months, decimal interestRate);

        protected decimal CalculateInterests(int months, decimal interestRate, int NoInterestMonths)
        {
            if (months <= NoInterestMonths)
            {
                return 0;
            }

            decimal interests = (months - NoInterestMonths) * interestRate;

            return interests;
        }

        protected decimal CalculateInterests(int months, decimal interestRate)
        {
            return this.CalculateInterests(months, interestRate, 0);
        }
    }
}