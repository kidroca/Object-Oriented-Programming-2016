namespace Telerik.Homeworks.OOP.Principles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Banks;
    using Banks.Customers;

    public class BankOperationsEntry
    {
        private static void Main(string[] args)
        {
            var joro = new Individual("Bate", "Joro");

            var bestBank = new Bank("Best Bank");

            bestBank.CreateNewLoan(joro, 1000);

            // Implement Account.InterestRate 
            // Implement when the Loan Mortage ends
            // Validations and encapsulation

            foreach (var acc in bestBank.Accounts)
            {
                Console.WriteLine(acc);
                Console.WriteLine();
            }
        }
    }
}
