using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.CallAStoredProcedure
{
    using _2.EmployeeDAOClass;

    class CallAStoredProcedure
    {
        static void Main(string[] args)
        {
            var context = new SoftUniDatabase();
            var projectsForEmployee = context.GetAllProjectsForAnEmployee("Ruth", "Ellerbrock");

            foreach (var project in projectsForEmployee)
            {
                Console.WriteLine(project);
            }
        }
    }
}
