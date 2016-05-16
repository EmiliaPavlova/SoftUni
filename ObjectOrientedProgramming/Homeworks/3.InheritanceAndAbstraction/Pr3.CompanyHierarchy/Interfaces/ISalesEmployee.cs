using System.Collections.Generic;

namespace Pr3.CompanyHierarchy.Interfaces
{
    interface ISalesEmployee : IEmployee
    {
        List<Sale> Sales { get; set; }
    }
}
