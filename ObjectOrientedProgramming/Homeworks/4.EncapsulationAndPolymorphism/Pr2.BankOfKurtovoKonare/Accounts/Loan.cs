using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr2.BankOfKurtovoKonare.Customers;

namespace Pr2.BankOfKurtovoKonare.Accounts
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal value, int months)
        {
            decimal result = base.CalculateInterest(value, months);
            switch (this.Customer.CustomerType)
            {
                case CustomerType.Individual:
                    if (months <= 3)
                    {
                        result = this.Balance;
                    }
                    break;
                case CustomerType.Company:
                    if (months <= 2)
                    {
                        result = this.Balance;
                    }
                    break;
            }
            return result; 
        }
    }
}
