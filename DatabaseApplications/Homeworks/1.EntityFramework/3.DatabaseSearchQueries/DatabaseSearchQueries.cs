namespace _3.DatabaseSearchQueries
{
    using System;
    using System.Linq;
    using _2.EmployeeDAOClass;

    class DatabaseSearchQueries
    {
        static void Main(string[] args)
        {
            //1:
            var context = new SoftUniDatabase();
            var searchedProjects = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.Projects
                        .Where(p => p.StartDate >= new DateTime(2002, 1, 1) &&
                                    p.StartDate <= new DateTime(2002, 12, 31))
                        .Select(p => new
                        {
                            ProjectName = p.Name,
                            StartDate = p.StartDate,
                            EndDate = p.EndDate
                        })
                });

            foreach (var empl in searchedProjects)
            {
                Console.WriteLine("Employee: {0}", empl.EmployeeName);
                foreach (var pr in empl.Projects)
                {
                    Console.WriteLine("{0}", pr.ProjectName);
                    Console.WriteLine("Start date {0:dd-MM-yyyy}, end date {1:dd-MM-yyyy}", pr.StartDate, pr.EndDate);
                }
                Console.WriteLine("Manager: {0}", empl.ManagerName);
            }
            Console.WriteLine();

            //2:
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .Select(a => new
                {
                    Address = a.AddressText,
                    Town = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .Take(10);

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees",
                    address.Address,
                    address.Town,
                    address.EmployeeCount);
            }
            Console.WriteLine();

            //3:
            var employeeById = context.Employees.Find(147);
            var employeeProjects = employeeById.Projects
                .OrderBy(p => p.Name)
                .Select(p => p.Name);
            Console.WriteLine("147. {0} {1} - {2}, {3}",
                employeeById.FirstName,
                employeeById.LastName,
                employeeById.JobTitle,
                string.Join(", ", employeeProjects));
            Console.WriteLine();

            //4:
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.HireDate,
                        e.JobTitle
                    })
                });

            Console.WriteLine(departments.Count());

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                    department.DepartmentName,
                    department.ManagerName,
                    department.Employees.Count());
            }
        }
    }
}
