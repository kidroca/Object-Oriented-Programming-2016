namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Worker : Human
    {
        public const uint MaxHoursPerDay = 8;

        public const uint WorkDaysPerWeek = 5;

        private decimal weekSalary;

        private uint workHoursPerDay;

        public Worker(string fname, string lname, decimal weekSalary, uint hours)
            : base(fname, lname)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = hours;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                // validate
                this.weekSalary = value;
            }
        }

        public uint WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value > MaxHoursPerDay)
                {
                    throw new ArgumentOutOfRangeException("Let this man have a break");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerDay = this.weekSalary / WorkDaysPerWeek;

            decimal moneyPerHour = moneyPerDay / this.workHoursPerDay;

            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + "\r\nMoney Per Hour: '{0}'", this.MoneyPerHour());
        }
    }
}
