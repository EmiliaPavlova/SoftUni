-- Problem 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
select FirstName, LastName, Salary from Employees 
where Salary = (select min(Salary) from Employees)

-- Problem 2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
select FirstName, LastName, Salary from Employees 
where Salary < (select min(Salary) from Employees) * 1.1

-- Problem 3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
select e.FirstName + ' ' + e.LastName as Employee, d.Name as Department, e.Salary from Employees e 
join Departments d on e.DepartmentID = d.DepartmentID
where e.Salary = (select min(Salary) from Employees e
where d.DepartmentID = e.DepartmentID)
order by d.Name

-- Problem 4.	Write a SQL query to find the average salary in the department #1.
select avg(Salary) as [Average Salary] from Employees
where DepartmentID = 1

-- Problem 5.	Write a SQL query to find the average salary in the "Sales" department.
select avg(e.Salary) as [Average Salary for Sales Department] from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
where d.Name = 'Sales'

-- Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.
select count(*) as [Sales Employees Count] from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
where d.Name = 'Sales'

-- Problem 7.	Write a SQL query to find the number of all employees that have manager.
select count(ManagerID) as [Employees with manager] from Employees

-- Problem 8.	Write a SQL query to find the number of all employees that have no manager.
select count(*) as [Employees without manager] from Employees
where ManagerID is null 

-- Problem 9.	Write a SQL query to find all departments and the average salary for each of them.
select d.Name as Department, avg(e.Salary) from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
group by d.Name

-- Problem 10.	Write a SQL query to find the count of all employees in each department and for each town.
select t.Name as Town, d.Name as Department, count(*) from Employees e
join Departments d on e.DepartmentID = d.DepartmentID
join Addresses a on e.AddressID = a.AddressID
join Towns t on a.TownID = t.TownID
group by t.Name, d.Name

-- Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.
select d.FirstName + ' ' + d.LastName as Manager, count(e.ManagerID) as [Employees count] from Employees d
join Employees e on d.ManagerID = e.ManagerID
group by d.FirstName, d.LastName
having count(e.ManagerID) = 5

-- Problem 12.	Write a SQL query to find all employees along with their managers.
select e.FirstName + ' ' + e.LastName as Employee,
isnull(d.FirstName + ' ' + d.LastName, '(no manager)') as Manager
from Employees e
left outer join Employees d on e.ManagerID = d.EmployeeID

-- Problem 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
select FirstName, LastName from Employees
where len(LastName) = 5

-- Problem 14.	Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 
select convert(varchar, getdate(), 104) + ' ' + convert(varchar, getdate(), 114)
select convert(varchar, getdate(), 113)

-- Problem 15.	Write a SQL statement to create a table Users.
create table Users(
	Id int identity,
	UserName nvarchar(20) unique not null,
	UserPassword nvarchar(20) not null,
	FullName nvarchar(40) not null,
	LastLogin datetime,
	constraint PK_Users primary key(Id),
	constraint PasswordMinLength check (datalength([UserPassword]) > 4)
)

insert into Users(UserName, UserPassword, FullName, LastLogin)
	values ('polipileto', 'passpoli','Poli Peteva', getdate()),
			('boomboom', '123456', 'Flin Smith', getdate()),
			('flower', 'primrose', 'Felicia Green', getdate() - 1),
			('thunder', 'bird', 'Jim Burn', getdate() - 2)
go

-- Problem 16.	Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
create view [Logged in today] as select * from Users
where datediff(day, LastLogin, getdate()) = 0
go

-- Problem 17.	Write a SQL statement to create a table Groups. 
create table Groups(
	Id int identity,
	Name nvarchar(20) unique,
	constraint PK_Groups primary key(Id)
)

-- Problem 18.	Write a SQL statement to add a column GroupID to the table Users.
alter table Users add GroupId int

alter table Users add constraint FK_Users_Groups foreign key(GroupId) references Groups(Id)

-- Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.
insert into Users(UserName, UserPassword, FullName, GroupId)
	values ('pilot', 'ars3257','Crazy Man', 1),
			('beauty', '123456', 'Lisa Nina', 2),
			('squirrel', 'rainforest', 'Anne Frey', 3),
			('siathefast', 's1i5a9', 'Sia Clain', 6)

insert into Groups(Name) values ('Administrators'), ('Moderators'), ('Users'), ('Spammers')

-- Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.
update Users set UserPassword = 'newpolipass'
where Id = 1

update Groups set Name = 'Mass Users'
where Name = 'Users'

-- Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.
delete from Users 
where Id = 4

delete from Groups
where Name = 'Spammers'

-- Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.
insert into Users(FullName, UserName, UserPassword)
select (FirstName + ' ' + LastName), 
(substring(FirstName, 0, 4) + lower(LastName)),
(substring(FirstName, 0, 2) + lower(LastName))
from Employees

-- Problem 23.	Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
update Users set UserPassword = null
where datediff(day, LastLogin, cast('2010-03-10' as date)) > 0

-- Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).
delete from Users
where UserPassword is null

-- Problem 25.	Write a SQL query to display the average employee salary by department and job title.
select d.Name, e.JobTitle as [Job Title], avg(e.Salary) as [Average Salary] from Employees e
join Departments d on e.DepartmentID = d.DepartmentID 
group by e.JobTitle, e.Salary, d.Name
order by d.Name

-- Problem 26.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
select d.Name, e.JobTitle, min(e.FirstName + ' ' + e.LastName) as Employee, min(e.Salary) as MinSalary from Employees e
	join Departments d on e.DepartmentID = d.DepartmentID
	group by e.JobTitle, e.Salary, d.Name
	order by d.Name

-- Problem 27.	Write a SQL query to display the town where maximal number of employees work.
select top 1 t.Name, count(t.Name) as [Number of employees] from Towns t
join Addresses a on t.TownID = a.TownID
join Employees e on a.AddressID = e.AddressID
group by t.Name
order by [Number of employees] desc

-- Problem 28.	Write a SQL query to display the number of managers from each town.
select t.Name, count(*) as [Number of managers] from Towns t
join Addresses a on t.TownID = a.TownID
join Employees e on a.AddressID = e.AddressID
where e.EmployeeID in
(select distinct ManagerID from Employees)
group by t.Name
order by [Number of managers] desc

-- Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.
create table WorkHours(
	Id int identity,
	EmployeeID int not null,
	[Date] date,
	Task nvarchar(20),
	[Hours] int,
	Comments nvarchar(30),
	constraint PK_WorkHours primary key(Id),
	constraint FK_Employees_WorkHours foreign key(EmployeeId)
		references Employees(EmployeeId)
)

-- Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.
insert into WorkHours(EmployeeID, [Date], Task, [Hours], Comments)
	values(1, getdate(), 'Task1', 3, 'Do it when you can'),
		(3, getdate() - 30, 'Task2', 48, 'Do it per two days'),
		(8, getdate() - 30, 'Task2', 48, 'Do it per two days')

update WorkHours set Task = 'Task3'
where EmployeeID = 8

-- Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
CREATE TABLE WorkHoursLogs(
	Id int IDENTITY,
	WorkHoursID int NOT NULL,
	EmployeeIdNEW int,
	EmployeeIdOLD int,
	DateNEW date,
	DateOLD date,
	TaskNEW nvarchar(20),
	TaskOLD nvarchar(20),
	HoursNEW int,
	HoursOLD int,
	CommentsNEW nvarchar(30),
	CommentsOLD nvarchar(30),
	Command nvarchar(10)
	CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),	
	)
Go

ALTER TABLE WorkHoursLogs  WITH CHECK 
ADD CONSTRAINT [FK_WorkHoursLogs_WorkHours] FOREIGN KEY(WorkHoursID)
REFERENCES WorkHours(ID) ON DELETE CASCADE
GO

CREATE TRIGGER WorkHoursLogsAI ON dbo.WorkHours
AFTER INSERT
AS
BEGIN
	--SET NOCOUNT ON;
	INSERT INTO WorkHoursLogs(WorkHoursID, EmployeeIdNEW, DateNEW, TaskNEW, HoursNEW, 
		CommentsNEW,  Command)	
	
	SELECT i.ID, i.EmployeeId, i.[Date], i.Task, i.[Hours], i.Comments, 'insert'
      FROM Inserted i
      
END
GO

CREATE TRIGGER WorkHoursLogsAU ON dbo.WorkHours
AFTER UPDATE AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO WorkHoursLogs(WorkHoursID, EmployeeIdOLD, DateOLD, TaskOLD, HoursOLD, 
	CommentsOLD, EmployeeIdNEW, DateNEW, TaskNEW, HoursNEW, CommentsNEW,  Command)	
	
	SELECT i.ID, d.EmployeeId, d.[Date], d.Task, d.[Hours], d.Comments,
		 i.EmployeeId, i.[Date], i.Task, i.[Hours], i.Comments, 'update'
      FROM Inserted i
      INNER JOIN Deleted d ON i.ID = d.ID
	  	
END
GO

CREATE TRIGGER WorkHoursLogsAD ON dbo.WorkHours
AFTER DELETE AS
BEGIN

	SET NOCOUNT ON;

	ALTER TABLE WorkHoursLogs
	NOCHECK CONSTRAINT FK_WorkHoursLogs_WorkHours;

	INSERT INTO WorkHoursLogs(WorkHoursID, EmployeeIdOLD, DateOLD, TaskOLD, HoursOLD, 
		CommentsOLD, Command)	
	
	SELECT d.ID, d.EmployeeId, d.[Date], d.Task, d.[Hours], d.Comments,
		 'delete'
      FROM Deleted d 
END
GO

-- Problem 32.	Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
/*
ALTER TABLE Employees
   DROP CONSTRAINT FK_Employees_Departments  

ALTER TABLE Employees
   ADD CONSTRAINT FK_Employees_Departments_Cascade
   FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) ON DELETE CASCADE
*/

DELETE  Employees
WHERE DepartmentID = 
	(SELECT DepartmentID 
	 FROM Departments
	 WHERE Name = 'Sales')

SELECT * FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ROLLBACK TRAN

-- Problem 33.	Start a database transaction and drop the table EmployeesProjects.
BEGIN TRAN

DROP TABLE EmployeesProjects

Commit TRAN

-- Problem 34.	Find how to use temporary tables in SQL Server.
SELECT * INTO ##TempTableProjects
FROM EmployeesProjects
 
 DROP TABLE EmployeesProjects
 
 CREATE TABLE EmployeesProjects
  (
   EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
   ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID) NOT NULL,
  )
 
 INSERT INTO EmployeesProjects
 SELECT * FROM  ##TempTableProjects