using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Pr3.CompanyHierarchy.People;

namespace Pr3.CompanyHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Person>()
            {
                new Manager("123", "Ben", "Green", 10000M, Department.Marketing, employees: new List<Employee>()
                {
                    new SalesEmployee("124", "Linn", "Smith", 1200M, new List<Sale>()),
                }),
                new Developer("126", "Gareth", "Mani", 2300M, new List<Project>()),
                new Customer("12345", "Sas", "Brum", 1234.5M),
            };

            employees.ForEach(Console.WriteLine);
        }
    }
}
