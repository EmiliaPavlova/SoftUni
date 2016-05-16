using Pr3.CompanyHierarchy.People;

namespace Pr3.CompanyHierarchy.Interfaces
{
    interface IEmployee : IPerson
    {
        decimal Salary { get; set; }
        Department Department { get; set; }
    }
}
