-- Problem 1.	All Diablo Characters
select Name from Characters
order by Name

-- Problem 2.	Games from 2011 and 2012 year
select top 50 Name as Game, CONVERT(date, Start, 1) as Start from Games
where YEAR(start) >= 2011 and YEAR(start) <= 2012
order by Start, Name

-- Problem 3.	User Email Providers
select 
	Username, 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) as [Email Provider] 
from Users
order by [Email Provider], Username

-- Problem 4.	Get users with IPAddress like pattern
select Username, IpAddress as [IP Address] from Users
where IpAddress like '___.1%.%.___'
order by Username

-- Problem 5.	Show All Games with Duration and Part of the Day
select 
	Name as Game, 
	case when DATEPART(hour, Start) >= 0 and DATEPART(hour, Start) < 12 then 'Morning'
		when DATEPART(hour, Start) >= 12 and DATEPART(hour, Start) < 18 then 'Afternoon'
		when DATEPART(hour, Start) >= 18 and DATEPART(hour, Start) < 24 then 'Evening' end as [Part of the Day], 
	case when Duration <= 3 then 'Extra Short' 
		when Duration > 3 and Duration <= 6 then 'Short' 
		when Duration > 6 and Duration <= 10 then 'Long' else 'Extra Long' end as Duration 
from Games
order by Name, Duration, [Part of the Day]

-- Problem 6.	Number of Users for Email Provider
select 
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) as [Email Provider],
	COUNT(Username) as [Number Of Users]
from Users
group by SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))
order by [Number Of Users] desc, [Email Provider]

-- Problem 7.	All User in Games
select g.Name as Game, gt.Name as [Game Type], u.Username, ug.Level, ug.Cash, c.Name as Character from Games g
join GameTypes gt on g.GameTypeId = gt.Id
join UsersGames ug on g.Id = ug.GameId
join Users u on ug.UserId = u.Id
join Characters c on ug.CharacterId = c.Id
order by Level desc, Username, g.Name

-- Problem 8.	Users in Games with Their Items
select u.Username, g.Name as Game, COUNT(i.Id) as [Items Count], SUM(i.Price) as [Items Price] from Users u
join UsersGames ug on u.Id = ug.UserId
join Games g on ug.GameId = g.Id
join UserGameItems ugi on ug.Id = ugi.UserGameId
join Items i on ugi.ItemId = i.Id
group by u.Username, g.Name
having COUNT(i.Id) >= 10
order by [Items Count] desc, [Items Price] desc, Username

-- Problem 9.	* User in Games with Their Statistics
select 
	u.Username, 
	g.Name as Game, 
	MAX(c.Name) Character,
	SUM(its.Strength) + MAX(gts.Strength) + MAX(cs.Strength) as Strength,
	SUM(its.Defence) + MAX(gts.Defence) + MAX(cs.Defence) as Defence,
	SUM(its.Speed) + MAX(gts.Speed) + MAX(cs.Speed) as Speed,
	SUM(its.Mind) + MAX(gts.Mind) + MAX(cs.Mind) as Mind,
	SUM(its.Luck) + MAX(gts.Luck) + MAX(cs.Luck) as Luck
from Users u
join UsersGames ug on u.Id = ug.UserId
join Games g on ug.GameId = g.Id
join GameTypes gt on gt.Id = g.GameTypeId
join [Statistics] gts on gts.Id = gt.BonusStatsId
join Characters c on ug.CharacterId = c.Id
join [Statistics] cs on cs.Id = c.StatisticId
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
join [Statistics] its on its.Id = i.StatisticId
group by u.Username, g.Name
order by Strength desc, Defence desc, Speed desc, Mind desc, Luck desc

-- Problem 10.	All Items with Greater than Average Statistics 
select i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind from Items i
join [Statistics] s on i.StatisticId = s.Id
where s.Speed > (select AVG(s.Speed) from Items i
	join [Statistics] s on i.StatisticId = s.Id)
and s.Luck > (select AVG(s.Luck) from Items i
	join [Statistics] s on i.StatisticId = s.Id)
and s.Mind > (select AVG(s.Mind) from Items i
	join [Statistics] s on i.StatisticId = s.Id)
order by i.Name

-- Problem 11.	Display All Items with Information about Forbidden Game Type
select i.Name as Item, i.Price, i.MinLevel, gt.Name as [Forbidden Game Type] from Items i
left join GameTypeForbiddenItems gtfi on i.Id = gtfi.ItemId
left join GameTypes gt on gtfi.GameTypeId = gt.Id
order by gt.Name desc, i.Name

-- Problem 12.	Buy items for user in game
insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Blackguard'),
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)
update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Blackguard')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Bottomless Potion of Amplification'),
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)
update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Bottomless Potion of Amplification')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Eye of Etlich (Diablo III)'),
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)
update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Eye of Etlich (Diablo III)')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Gem of Efficacious Toxin'),
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)
update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Gem of Efficacious Toxin')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Golden Gorget of Leoric'),
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)
update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Golden Gorget of Leoric')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

insert into UserGameItems(ItemId, UserGameId)
values 
	(
		(select Id from Items where Name = 'Hellfire Amulet'),
		(select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')
	)
update UsersGames
set Cash = Cash - (select Price from Items where Name = 'Hellfire Amulet')
where Id = (select ug.Id from UsersGames ug 
			join Users u on u.Id = ug.UserId
			join Games g on g.Id = ug.GameId
			where u.Username = 'Alex' and g.Name = 'Edinburgh')

select u.Username, g.Name, ug.Cash, i.Name as [Item Name] from Users u
join UsersGames ug on u.Id = ug.UserId
join Games g on ug.GameId = g.Id
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
where g.Name = 'Edinburgh'
order by i.Name

-- Problem 13.	Massive shopping
SET XACT_ABORT ON 
BEGIN TRANSACTION [Tran1]

BEGIN TRY

	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 11 AND 12

COMMIT TRANSACTION [Tran1]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran1]
END CATCH 
GO

BEGIN TRANSACTION [Tran2]

BEGIN TRY

	UPDATE 
		UsersGames 
	SET 
		Cash = Cash - (
			SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21
		) 
	WHERE Id = 110

	INSERT INTO UserGameItems (UserGameId, ItemId)
	SELECT 110, Id FROM Items WHERE MinLevel BETWEEN 19 AND 21

COMMIT TRANSACTION [Tran2]

END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION [Tran2]
END CATCH 
GO

SELECT Items.Name [Item Name] 
FROM Items 
INNER JOIN UserGameItems ON Items.Id = UserGameItems.ItemId 
WHERE UserGameId = 110 
ORDER BY [Item Name]

-- Problem 14.	Scalar Function: Cash in User Games Odd Rows
create function fn_CashInUsersGames(@gameName nvarchar(max))
returns table
as return
with prices as (
	select Cash, (ROW_NUMBER() OVER(ORDER BY ug.Cash desc)) as RowNum from UsersGames ug
	join Games g on ug.GameId = g.Id
	where g.Name = @gameName
) 
select SUM(Cash) [SumCash] FROM prices WHERE RowNum % 2 = 1
GO

select * from fn_CashInUsersGames('Bali')
union
select * from fn_CashInUsersGames('Lily Stargazer')
union
select * from fn_CashInUsersGames('Love in a mist')
union
select * from fn_CashInUsersGames('Mimosa')
union
select * from fn_CashInUsersGames('Ming fern')

-- Problem 15.	Trigger
create trigger tr_UserGameItems on UserGameItems
instead of insert
as
	insert into UserGameItems
	select ItemId, UserGameId from inserted
	where 
		ItemId in (
			select Id 
			from Items 
			where MinLevel <= (
				select [Level]
				from UsersGames 
				where Id = UserGameId
			)
		)
go

-- Add bonus cash for users
update UsersGames
set Cash = Cash + 50000 + (SELECT SUM(i.Price) FROM Items i 
							JOIN UserGameItems ugi ON ugi.ItemId = i.Id 
							WHERE ugi.UserGameId = UsersGames.Id)
where UserId in (
	select Id 
	from Users 
	where Username in ('loosenoise', 'baleremuda', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
)
and GameId = (select Id from Games where Name = 'Bali')

-- Buy items for users
insert into UserGameItems (UserGameId, ItemId)
select  UsersGames.Id, i.Id 
from UsersGames, Items i
where UserId in (
	select Id 
	from Users 
	where Username in ('loosenoise', 'baleremuda', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
) and GameId = (select Id from Games where Name = 'Bali' ) and ((i.Id > 250 and i.Id < 300) or (i.Id > 500 and i.Id < 540))

-- Get cash from users
update UsersGames
set Cash = Cash - (SELECT SUM(i.Price) FROM Items i 
					JOIN UserGameItems ugi ON ugi.ItemId = i.Id 
					WHERE ugi.UserGameId = UsersGames.Id)
where UserId in (
	select Id 
	from Users 
	where Username in ('loosenoise', 'baleremuda', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
)
and GameId = (select Id from Games where Name = 'Bali')

select u.Username, g.Name, ug.Cash, i.Name [Item Name] from UsersGames ug
join Games g on ug.GameId = g.Id
join Users u on ug.UserId = u.Id
join UserGameItems ugi on ugi.UserGameId = ug.Id
join Items i on i.Id = ugi.ItemId
where g.Name = 'Bali'
order by Username, [Item Name]

-- 