using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr2.BankOfKurtovoKonare.Customers;

namespace Pr2.BankOfKurtovoKonare.Accounts
{
    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal value, int months)
        {
            if (value > 0 && value <= 1000)
            {
                return 0;
            }
            return base.CalculateInterest(value, months);
        }

        public void Withdraw(decimal value)
        {
            if (value > this.balance)
            {
                throw new ArgumentException("Not enough money in the account.");
            }
            this.Balance -= value;
        }
    }
}
