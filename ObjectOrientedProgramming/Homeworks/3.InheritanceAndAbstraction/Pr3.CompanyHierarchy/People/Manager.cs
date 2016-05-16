using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr3.CompanyHierarchy.Interfaces;

namespace Pr3.CompanyHierarchy.People
{
    public class Manager : Employee, IManager
    {
        private List<Employee> employees;

        public Manager(string id, string firstName, string lastName, decimal salary, Department department, List<Employee> employees)
            : base(id, firstName, lastName, salary, department)
        {
            this.Employees = employees;
        }

        public List<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }
    }
}
