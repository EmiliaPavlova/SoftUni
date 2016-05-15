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