using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr2.BankOfKurtovoKonare.Customers;

namespace Pr2.BankOfKurtovoKonare.Accounts
{
    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal value, int months)
        {
            decimal interest = base.CalculateInterest(value, months);
            switch (this.Customer.CustomerType)
            {
                case CustomerType.Individual:
                    if (months <= 6)
                    {
                        return this.Balance;
                    }
                    break;
                case CustomerType.Company:
                    if (months <= 12)
                    {
                        return this.Balance;
                    }
                    break;
            }
            return interest;
        }
    }
}
