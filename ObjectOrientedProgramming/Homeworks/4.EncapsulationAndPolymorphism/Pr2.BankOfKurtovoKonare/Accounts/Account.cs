using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr2.BankOfKurtovoKonare.Customers;

namespace Pr2.BankOfKurtovoKonare.Accounts
{
    public abstract class Account : IAccount
    {
        private Customer customer;
        protected decimal balance;
        private decimal interestRate;

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer { get; set; }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public virtual decimal CalculateInterest(decimal value, int months)
        {
            decimal result = value * (1 + this.InterestRate * months);
            return result;
        }

        public virtual void Deposit(decimal value)
        {
            this.balance += value;
        }
    }
}
