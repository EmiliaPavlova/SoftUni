using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pr3.CompanyHierarchy.Interfaces;

namespace Pr3.CompanyHierarchy.People
{
    public class Developer : Employee, IDeveloper
    {
        public Developer(string id, string firstName, string lastName, decimal salary, List<Project> projects)
            : base(id, firstName, lastName, salary, Department.Production)
        {
            this.Project = projects;
        }

        public List<Project> Project { get; set; }
    }
}
