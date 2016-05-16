using System.Collections.Generic;

namespace Pr3.CompanyHierarchy.Interfaces
{
    interface IDeveloper : IEmployee
    {
        List<Project> Project { get; set; }
    }
}
