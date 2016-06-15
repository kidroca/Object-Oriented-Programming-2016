namespace Telerik.Homeworks.OOP.Principles.Banks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using Accounts;
    using Accounts.Balances;
    using Customers;

    public class Bank
    {
        private List<Account> accounts;

        public Bank(string name)
        {
            this.Name = name;

            this.accounts = new List<Account>();
            this.Accounts = accounts.AsReadOnly();
        }

        public string Name { get; set; }

        public ReadOnlyCollection<Account> Accounts { get; private set; }

        public void CreateNewDeposit(Customer customer, decimal initialFunds)
        {
            var customerDeposit = new Deposit(customer, new Balance(initialFunds));
            this.accounts.Add(customerDeposit);
        }

        public void CreateNewLoan(Customer customer, decimal loanAmount)
        {
            var customerLoan = new Loan(customer, new Balance(-loanAmount));
            this.accounts.Add(customerLoan);
        }

        public void CreateNewMortage(Customer customer, decimal mortageAmount)
        {
            var customerMortage = new Mortage(customer, new Balance(-mortageAmount));
        }

        public void RemoveAccount(Account account)
        {
            this.accounts.Remove(account);
        }
    }
}
