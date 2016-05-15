namespace _4.NativeSQLQuery
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using _2.EmployeeDAOClass;

    class NativeSQLQuery
    {
        static void Main(string[] args)
        {
            var context = new SoftUniDatabase();
            //initialize database connection
            var count = context.Addresses.Count();
            var sw = new Stopwatch();
            sw.Start();
            PrintNameWithNativeQuery(context);
            Console.WriteLine("Native: {0}", sw.Elapsed);
            context.Database.ExecuteSqlCommand("CHECKPOINT;  DBCC DROPCLEANBUFFERS;");
            sw.Restart();
            PrintNamesWithLinqQuery(context);
            Console.WriteLine("Linq: {0}", sw.Elapsed);
        }

        private static void PrintNameWithNativeQuery(SoftUniDatabase context)
        {
            // EF generated query from SQL Profiler
            var employees = context.Database.SqlQuery<int>(@"
                SELECT 
                [GroupBy1].[A1] AS [C1]
                FROM ( SELECT 
                    COUNT(1) AS [A1]
                    FROM [dbo].[Employees] AS [Extent1]
                    WHERE  EXISTS (SELECT 
                        1 AS [C1]
                        FROM  [dbo].[EmployeesProjects] AS [Extent2]
                        INNER JOIN [dbo].[Projects] AS [Extent3] ON [Extent3].[ProjectID] = [Extent2].[ProjectID]
                        WHERE ([Extent1].[EmployeeID] = [Extent2].[EmployeeID]) AND ((DATEPART (year, [Extent3].[StartDate])) >= 2002) AND ((DATEPART (year, [Extent3].[StartDate])) < 2003)
                    )
                )  AS [GroupBy1]");

            foreach (var employee in employees)
            {
                // Materialize query
            }
        }

        private static void PrintNamesWithLinqQuery(SoftUniDatabase context)
        {
            var empl = context.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year >= 2002 && p.StartDate.Year < 2003))
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.Projects
                        .Where(p => p.StartDate.Year >= 2002 && p.StartDate.Year < 2003)
                });

            foreach (var employee in empl)
            {
                // Materialize query
            }
            //Console.WriteLine(empl.Count());
        }
    }
}
