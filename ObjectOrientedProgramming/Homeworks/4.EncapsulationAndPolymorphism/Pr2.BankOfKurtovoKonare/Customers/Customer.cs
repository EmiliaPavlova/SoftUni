using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pr2.BankOfKurtovoKonare.Customers
{
    public class Customer
    {
        private string name;
        private CustomerType customerType;

        public Customer(string name, CustomerType customerType)
        {
            this.Name = name;
            this.CustomerType = customerType;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (!Regex.IsMatch(value, "\\w+"))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.name = value;
            }
        }

        public CustomerType CustomerType { get; set; }
    }
}
