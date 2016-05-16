using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr3.CompanyHierarchy.Interfaces;

namespace Pr3.CompanyHierarchy.People
{
    public class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public Employee(string id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative");
                }
                this.salary = value;
            }
        }

        public Department Department { get; set; }

        public override string ToString()
        {
            string name = string.Format("My names is {0} {1} and I'm a {2}. My salary is {3} euro.", 
                this.FirstName, this.LastName, this.GetType().Name, this.Salary);
            return name;
        }
    }
}
