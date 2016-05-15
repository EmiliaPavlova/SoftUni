-- Problem 1.	All Diablo Characters
select Name from Characters
order by Name

-- Problem 2.	Games from 2011 and 2012 year
select top 50 Name as Game, convert(date, Start) as Start from Games
where Start between '2011' and '2013'
order by Start, Name

-- Problem 3.	User Email Providers
select 
	Username, 
	(select right(Email, len(Email) - charindex('@', email)) Domain) as [Email Provider]
from Users
where len(Email) > 0
order by [Email Provider], Username

-- Problem 4.	Get users with IPAddress like pattern
select Username, IpAddress as [IP Address] from Users
where IpAddress like '___.1%.%.___'
order by Username

-- Problem 5.	Show All Games with Duration and Part of the Day
select 
	Name as Game, 
	(case when datepart(hh, Start) between 0 and 11 then 'Morning'
		when datepart(hh, Start) between 12 and 17 then 'Afternoon' 
		when datepart(hh, Start) between 18 and 23 then 'Evening'end) as [Part of the Day], 
	(case when Duration  <= 3 then 'Extra Short'
		when Duration between 4 and 6 then 'Short'
		when Duration >= 6 then 'Long' 
		when Duration is null then 'Extra Long' end) as Duration
from Games
order by Name, Duration, [Part of the Day]

-- Problem 6.	Number of Users for Email Provider
select 
	(select right(Email, len(Email) - charindex('@', email)) Domain) as [Email Provider],
	count(Id) as [Number Of Users]
from Users
group by (right(Email, len(Email) - charindex('@', email)))
order by [Number Of Users] desc, [Email Provider]

-- Problem 7.	All User in Games
select g.Name as Game, gt.Name as [Game Type], u.Username, ug.Level, ug.Cash, c.Name as Character 
from Games g
join GameTypes gt on g.GameTypeId = gt.Id
join UsersGames ug on g.Id = ug.GameId
join Users u on ug.UserId = u.Id
join Characters c on ug.CharacterId = c.Id
order by ug.Level desc, u.Username, g.Name

-- Problem 8.	Users in Games with Their Items
select u.Username, g.Name as Game, count(i.Id) as [Items Count], sum(i.Price) as [Items Price]
from Users u
join UsersGames ug on u.Id = ug.UserId
join Games g on ug.GameId = g.Id
join UserGameItems ugi on ug.Id = ugi.UserGameId
join Items i on ugi.ItemId = i.Id
group by u.Username, g.Name
having count(i.Id) >= 10
order by [Items Count] desc, [Items Price] desc, u.Username

-- Problem 9.	* User in Games with Their Statistics
select 
	u.Username, 
	g.Name as Game, 
	c.Name as [Character], 
	sch.Strength + sgt.Strength + si.Strength as Strength,
	sch.Defence + sgt.Defence + si.Defence as Defence,
	sch.Speed + sgt.Speed + si.Speed as Speed,
	sch.Mind + sgt.Mind + si.Mind as Mind,
	sch.Luck + sgt.Luck + si.Luck as Luck
from Users u
join UsersGames ug on u.Id = ug.UserId
join Games g on ug.GameId = g.Id
join Characters c on ug.CharacterId = c.Id
join [Statistics] sch on c.StatisticId = sch.Id
join GameTypes gt on g.GameTypeId = gt.Id
join [Statistics] sgt on c.StatisticId = sgt.Id
join UsersGames us on u.Id = us.UserId
join UserGameItems ugi on ug.Id = ugi.UserGameId
join Items i on ugi.ItemId = i.Id
join [Statistics] si on i.StatisticId = si.Id
--group by u.Username, g.Name, c.Name
order by Strength desc, Defence desc, Speed desc, Mind desc, Luck desc



-- Problem 10.	All Items with Greater than Average Statistics
declare @avgSpeed int = (select avg(Speed) from [Statistics])
declare @avgLuck int = (select avg(Luck) from [Statistics])
declare @avgMind int = (select avg(Mind) from [Statistics])
select 
	i.Name,
	i.Price,
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
from Items i
join [Statistics] s on i.StatisticId = s.Id
group by i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind
having s.Speed > @avgSpeed and s.Luck > @avgLuck and s.Mind > @avgMind
order by i.Name

-- Problem 11.	Display All Items with Information about Forbidden Game Type
select i.Name as Item, i.Price, i.MinLevel, gt.Name as [Forbidden Game Type]
from Items i
left join GameTypeForbiddenItems gtfi on i.Id = gtfi.ItemId
left join GameTypes gt on gtfi.GameTypeId = gt.Id
order by [Forbidden Game Type] desc, Item

-- Problem 12.	Buy items for user in game
insert into UserGameItems(ItemId, UserGameId)
	values (51, 5), --Blackguard
	(71, 5), --Bottomless Potion of Amplification
	(157, 5), --Eye of Etlich (Diablo III)
	(184, 5), --Gem of Efficacious Toxin
	(197, 5), --Golden Gorget of Leoric 
	(223, 5) --Hellfire Amulet
where g.Id from Games g = 221

insert into Monasteries(Name, CountryCode)
	values ('Hanga Abbey', (select CountryCode from Countries where CountryName = 'Tanzania'))
-- id 221 Edinburgh

update UsersGames
set Cash = 4702
where UserId = 5

-- 2
select
	u.Username,
	g.Name,
	ug.Cash,
	i.Name as [Item Name]
from Users u
join UsersGames ug on u.Id = ug.UserId
join Games g on ug.GameId = g.Id
join UserGameItems ugi on ug.Id = ugi.UserGameId
join Items i on ugi.ItemId = i.Id
where g.Name = 'Edinburgh'
order by i.Name


-- Problem 13.	Massive shopping

-- Problem 14.	Scalar Function: Cash in User Games Odd Rows
IF (object_id(N'fn_CashInUsersGames') IS NOT NULL)
DROP FUNCTION fn_CashInUsersGames
GO

CREATE FUNCTION fn_CashInUsersGames()
	RETURNS int
AS
BEGIN
END


-- Problem 15.	Trigger

-- Problem 16.	Design a Database Schema in MySQL and Write a Query
use `job portal`;

CREATE TABLE `users` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    fullname NVARCHAR(50));
    
CREATE TABLE `job_ads` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    title NVARCHAR(50) NOT NULL,
    description text,
    author_id INT NOT NULL REFERENCES users(id),
    salary_id INT NOT NULL REFERENCES salaries(id));
    
CREATE TABLE `job_ad_applications` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    job_ad_id INT NOT NULL REFERENCES job_ads(id),
    user_id INT NOT NULL REFERENCES users(id));
    
CREATE TABLE `salaries` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    from_value decimal NOT NULL,
    to_value decimal(4,0) NOT NULL);

insert into users (username, fullname)
values ('pesho', 'Peter Pan'),
('gosho', 'Georgi Manchev'),
('minka', 'Minka Dryzdeva'),
('jivka', 'Jivka Goranova'),
('gago', 'Georgi Georgiev'),
('dokata', 'Yordan Malov'),
('glavata', 'Galin Glavomanov'),
('petrohana', 'Peter Petromanov'),
('jubata', 'Jivko Jurandov'),
('dodo', 'Donko Drozev'),
('bobo', 'Bay Boris');

insert into salaries (from_value, to_value)
values (300, 500),
(400, 600),
(550, 700),
(600, 800),
(1000, 1200),
(1300, 1500),
(1500, 2000),
(2000, 3000);

insert into job_ads (title, description, author_id, salary_id)
values ('PHP Developer', NULL, (select id from users where username = 'gosho'), (select id from salaries where from_value = 300)),
('Java Developer', 'looking to hire Junior Java Developer to join a team responsible for the development and maintenance of the payment infrastructure systems', (select id from users where username = 'jivka'), (select id from salaries where from_value = 1000)),
('.NET Developer', 'net developers who are eager to develop highly innovative web and mobile products with latest versions of Microsoft .NET, ASP.NET, Web services, SQL Server and related applications.', (select id from users where username = 'dokata'), (select id from salaries where from_value = 1300)),
('JavaScript Developer', 'Excellent knowledge in JavaScript', (select id from users where username = 'minka'), (select id from salaries where from_value = 1500)),
('C++ Developer', NULL, (select id from users where username = 'bobo'), (select id from salaries where from_value = 2000)),
('Game Developer', NULL, (select id from users where username = 'jubata'), (select id from salaries where from_value = 600)),
('Unity Developer', NULL, (select id from users where username = 'petrohana'), (select id from salaries where from_value = 550));

insert into job_ad_applications(job_ad_id, user_id)
values 
	((select id from job_ads where title = 'C++ Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Game Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'JavaScript Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'Unity Developer'), (select id from users where username = 'petrohana')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'jivka')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'jivka'));


-- 3
select u.username, u.fullname, ja.title as Job, s.from_value as `From Value`, s.to_value as `To Value` from job_ad_applications jaa
join users u on u.id = jaa.user_id
join job_ads ja on jaa.job_ad_id = ja.id
join salaries s on s.id = ja.salary_id
order by u.username, ja.title
