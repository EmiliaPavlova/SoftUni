-- Problem 1.	Create a database with two tables. 
-- Persons (id (PK), first name, last name, SSN) and Accounts (id (PK), person id (FK), balance). 

create table Persons (
	PersonId int identity not null,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	SSN nvarchar(20)
	constraint PK_PersonID primary key(PersonID)
)

create table Accounts (
	AccountId int identity,
	PersonId int,
	Balance money
	constraint PK_AccountId primary key(AccountId)
	constraint FK_PersonId foreign key(PersonId) references Persons(PersonId)
)

insert into Persons(FirstName, LastName, SSN)
	values('Ina', 'Petrova', '123456'),
			('Misho', 'Radev', '654987'),
			('Asen', 'Patev', '528652')
go
 
use SoftUni
go

create proc dbo.usp_SelectPersonsNames
as
	select FirstName + ' ' + LastName
	from dbo.Persons
go

exec dbo.usp_SelectPersonsNames


-- Problem 2.	Create a stored procedure
-- Create a stored procedure that accepts a number as a parameter 
-- and returns all persons who have more money in their accounts than the supplied number.

use SoftUni
go

alter proc dbo.usp_SelectMoney (@leverageBalance int = 200)
as
	select p.FirstName + ' ' + p.LastName
    from dbo.Persons p inner join dbo.Accounts a
    on p.PersonID = a.PersonID
    where a.Balance >= @leverageBalance
go
 
exec usp_SelectMoney 400


-- Problem 3.	Create a function with parameters
-- Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.

use SoftUni
go

create proc dbo.usp_CalculateSum (
	@sum int = 100,
	@interest int = 10,
	@monthsN int = 24,
	@result int output
)
as
	set @result = @sum + (@monthsN / 12) * ((@interest * @SUM) / 100)
go

declare @answer int
exec usp_CalculateSum 100, 10, 24, @answer output
select @answer


-- Problem 4.	Create a stored procedure that uses the function from the previous example.
-- Create a stored procedure that uses the function from the previous example to give an interest to a person's account 
-- for one month. It should take the AccountId and the interest rate as parameters.

use SoftUni
go

create proc dbo.usp_GiveInterest (
        @id int = 4,
        @interest int,
        @RESULT money output
)
as
        declare @sumz money
        set @sumz = (select a.Balance from dbo.Accounts a
                    inner join dbo.Persons p on p.PersonID = a.PersonID and p.PersonID = @id)

   declare @result int
exec usp_CalculateSum 5, 2,24, @result output         
go
       
declare @final money
exec usp_GiveInterest 1, 10, @final output
select @final


-- Problem 5.	Add two more stored procedures WithdrawMoney and DepositMoney.
-- Add two more stored procedures WithdrawMoney (AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.

create proc dbo.usp_WithdrawMoney (
        @AccountID int,
        @money money,
        @RESULT money output
)
as
        declare @curBalance money
        set @curBalance = (
                select a.Balance
                from dbo.Accounts a
                where a.AccountID = @AccountID
                )
        set @RESULT = @curBalance - @money
        update dbo.Accounts
                set Balance = @RESULT
                where(Accounts.AccountID = @AccountID)
go
 
declare @answer money
exec usp_WithdrawMoney 1, 50, @answer output
select @answer
 
-- deposit
 
create proc dbo.usp_DepositMoney (
        @AccountID int,
        @money money,
        @RESULT money output
)
as
        declare @curBalance money
        set @curBalance = (
                select a.Balance
                from dbo.Accounts a
                where a.AccountID = @AccountID
                )
        set @RESULT = @curBalance + @money
        update dbo.Accounts
                set Balance = @RESULT
                where(Accounts.AccountID = @AccountID)
go
 
declare @answer money
exec usp_DepositMoney 1, 50, @answer output
select @answer


-- Problem 6.	Create table Logs.
-- Create another table – Logs (LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

create table Logs(
        LogID int identity,
        AccountID int,
        NewSum money,
        constraint PK_LogID primary key(LogID),
        constraint FK_AccountID foreign key(AccountID)
                references Accounts(AccountID)
)
 
create trigger tr_AccountsUpdate on dbo.Accounts for update
as
        begin
        insert into dbo.Logs
                select a.AccountID as AccountID,
                a.Balance as NewSum
        from inserted a
        end
go
declare @answer money
exec usp_WithdrawMoney 4, 50, @answer output
select @answer