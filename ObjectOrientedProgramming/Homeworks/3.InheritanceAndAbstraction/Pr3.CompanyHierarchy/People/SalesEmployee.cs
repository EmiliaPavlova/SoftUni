using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr3.CompanyHierarchy.Interfaces;

namespace Pr3.CompanyHierarchy.People
{
    public class SalesEmployee : Employee, ISalesEmployee
    {
        public SalesEmployee(string id, string firstName, string lastName, decimal salary, List<Sale> sales)
            : base(id, firstName, lastName, salary, Department.Sales)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales { get; set; }
    }
}
