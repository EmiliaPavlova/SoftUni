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
