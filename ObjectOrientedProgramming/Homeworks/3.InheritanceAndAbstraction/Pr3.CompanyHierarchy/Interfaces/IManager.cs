using System.Collections.Generic;
using Pr3.CompanyHierarchy.People;

namespace Pr3.CompanyHierarchy.Interfaces
{
    interface IManager : IEmployee
    {
        List<Employee> Employees { get; set; }
    }
}
