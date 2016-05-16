using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr2.BankOfKurtovoKonare.Accounts;
using Pr2.BankOfKurtovoKonare.Customers;

namespace Pr2.BankOfKurtovoKonare
{
    class Program
    {
        static void Main(string[] args)
        {
            Deposit depositIndividual = new Deposit(new Customer("A.J.", CustomerType.Individual), 20000M, 2.5M);
            Console.WriteLine(depositIndividual.Balance);
            depositIndividual.Deposit(1000M);
            Console.WriteLine(depositIndividual.Balance);
            depositIndividual.Withdraw(1000m);
            Console.WriteLine(depositIndividual.Balance);
        }
    }
}
