namespace _2.EmployeeDAOClass
{
    using System;
    using EntityFrameworkHW;

    class EmployeeDAOClass
    {
        static void Main(string[] args)
        {
            var employee = Methods.FindByKey(10);
            Console.WriteLine(employee.FirstName);
            Methods.Modify(employee, "Sunny");
            employee.FirstName = "Bee";
            Methods.Add(employee);
            Console.WriteLine(employee.FirstName);
        }
    }
}
