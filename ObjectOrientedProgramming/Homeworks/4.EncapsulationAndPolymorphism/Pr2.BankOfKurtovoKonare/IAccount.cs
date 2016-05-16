using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr2.BankOfKurtovoKonare
{
    interface IAccount
    {
        void Deposit(decimal money);

        decimal CalculateInterest(decimal value, int months);
    }
}
