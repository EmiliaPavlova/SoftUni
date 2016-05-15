namespace EntityFrameworkHW
{
    using System.Data.Entity.Core;
    using _2.EmployeeDAOClass;

    public static class Methods
    {
        private static SoftUniDatabase context = new SoftUniDatabase();

        public static void Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public static Employee FindByKey(object key)
        {
            var employee = context.Employees.Find(key);

            if (employee == null)
            {
                throw new ObjectNotFoundException("No employee found");
            }

            return employee;
        }

        public static void Modify(Employee employee, string newFirstName)
        {
            var id = employee.EmployeeID;
            var dbEmployee = context.Employees.Find(id);
            dbEmployee.FirstName = newFirstName;
            context.SaveChanges();
        }

        public static void Delete(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
    }
}
