-- Problem 4.	Write a SQL query to find all information about all departments (use "SoftUni" database).
select * from Departments

-- Problem 5.	Write a SQL query to find all department names.
select Name from Departments

-- Problem 6.	Write a SQL query to find the salary of each employee. 
select Salary from Employees

-- Problem 7.	Write a SQL to find the full name of each employee. 
select FirstName + ' ' + isnull(MiddleName + ' ', '') + LastName as [Full Name] from Employees

-- Problem 8.	Write a SQL query to find the email addresses of each employee.
select FirstName + '.' + LastName + '@softuni.bg' as [Full Email Addresses] from Employees

-- Problem 9.	Write a SQL query to find all different employee salaries. 
select distinct Salary from Employees

-- Problem 10.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
select * from Employees where JobTitle = 'Sales Representative'

-- Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA".
select FirstName from Employees where FirstName like 'sa%'

-- Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei".
select LastName from Employees where LastName like '%ei%'

-- Problem 13.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
select Salary from Employees where Salary between 20000 and 30000

-- Problem 14.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
select FirstName, LastName from Employees where Salary in (25000, 14000, 12500, 23600)
select FirstName, LastName from Employees where Salary = 25000 or Salary = 14000 or Salary = 12500 or Salary = 23600

-- Problem 15.	Write a SQL query to find all employees that do not have manager.
select * from Employees where ManagerID is null

-- Problem 16.	Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
select * from Employees where Salary > 5000 order by Salary desc

-- Problem 17.	Write a SQL query to find the top 5 best paid employees.
select top 5 * from Employees order by Salary desc

-- Problem 18.	Write a SQL query to find all employees along with their address.
select e.FirstName, e.LastName, a.AddressText from Employees e
	inner join Addresses a on e.AddressID = a.AddressID

-- Problem 19.	Write a SQL query to find all employees and their address.
select e.FirstName, e.LastName, a.AddressText from Employees e, Addresses a
	where e.AddressID = a.AddressID

-- Problem 20.	Write a SQL query to find all employees along with their manager.
select e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName as Manager from Employees e
	inner join Employees m on e.ManagerID = m.EmployeeID

-- Problem 21.	Write a SQL query to find all employees, along with their manager and their address.
select e.FirstName, e.LastName, a.AddressText as Address, m.FirstName + ' ' + m.LastName as Manager from Employees e
	inner join Employees m on e.ManagerID = m.EmployeeID
	inner join Addresses a on e.AddressID = a.AddressID

-- Problem 22.	Write a SQL query to find all departments and all town names as a single list.
select t.Name as [Towns and departments] from Towns t
union
select d.Name from Departments d

-- Problem 23.	Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 
select e.FirstName + ' ' + e.LastName as Employee, m.FirstName + ' ' + m.LastName as Manager from Employees m
	right join Employees e on m.EmployeeID = e.ManagerID

-- Problem 24.	Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
select e.FirstName + ' ' + e.LastName as Employee, d.Name as Department, e.HireDate from Employees e
	join Departments d on e.DepartmentID = d.DepartmentID
	where d.Name = 'Sales' OR d.Name = 'Finance' 
		AND e.HireDate BETWEEN '1994-12-31' AND '2006-01-01'