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