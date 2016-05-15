-- Problem 1.	All Teams
select TeamName from Teams
order by TeamName

-- Problem 2.	Biggest Countries by Population
select top 50 CountryName, Population from Countries
order by Population desc, CountryName

-- Problem 3.	Countries and Currency (Eurzone)
select CountryName, CountryCode, (case
	when CurrencyCode = 'EUR' then 'Inside'
	else 'Outside' end) as Eurozone from Countries
order by CountryName

-- Problem 4.	Teams Holding Numbers
select Teamname as [Team Name], CountryCode as[Country Code] from Teams
where TeamName like '%[0-9]%'
order by CountryCode

-- Problem 5.	International Matches
select c1.CountryName as [Home Team], c2.CountryName as [Away Team], im.MatchDate as [Match Date]
from InternationalMatches im
join Countries c1 on im.HomeCountryCode = c1.CountryCode
join Countries c2 on im.AwayCountryCode = c2.CountryCode
order by im.MatchDate desc

-- Problem 6.	*Teams with their League and League Country
select 
	t.TeamName as [Team Name], l.LeagueName as League, (case
	when l.CountryCode is null then 'International'
	else c.CountryName end) as [League Country] from Teams t
join Leagues_Teams lt on t.Id = lt.TeamId
join Leagues l on lt.LeagueId = l.Id
left join Countries c on c.CountryCode = l.CountryCode
order by  t.TeamName, l.LeagueName

-- Problem 7.	* Teams with more than One Match
select 
	t.TeamName as Team, 
	(select count(distinct tm.Id) from TeamMatches tm
	where tm.HomeTeamId = t.Id or tm.AwayTeamId = t.Id) as [Matches Count]
from Teams t
where 
	(select count(distinct tm.Id) from TeamMatches tm
	where tm.HomeTeamId = t.Id or tm.AwayTeamId = t.Id) > 1
order by t.TeamName

-- Problem 8.	Number of Teams and Matches in Leagues
select 
	l.LeagueName as [League Name], 
	count(distinct lt.TeamId) as Teams, 
	count(distinct tm.Id) as Matches,
	isnull(avg(tm.HomeGoals + tm.AwayGoals), 0) as [Average Goals]
from Leagues l
left join Leagues_Teams lt on l.Id = lt.LeagueId
left join TeamMatches tm on l.Id = tm.LeagueId
group by l.LeagueName
order by Teams desc, Matches desc

-- Problem 9.	Total Goals per Team in all Matches
select 
	t.TeamName, 
	isnull((select sum(tm.HomeGoals) from TeamMatches tm where tm.HomeTeamId = t.Id), 0) + 
    isnull((select sum(tm.AwayGoals) from TeamMatches tm where tm.AwayTeamId = t.Id), 0) as [Total Goals]
from Teams t
order by [Total Goals] desc, t.TeamName

-- Problem 10.	Pairs of Matches on the Same Day
select tm1.MatchDate as [First Date], tm2.MatchDate as [Second Date] from TeamMatches tm1, TeamMatches tm2
where tm2.MatchDate > tm1.MatchDate and datediff(day, tm1.MatchDate, tm2.MatchDate) < 1
order by tm1.MatchDate desc, tm2.MatchDate desc

-- Problem 11.	Mix of Team Names
select lower(substring(t1.TeamName, 1, len(t1.TeamName) - 1) + reverse (t2.TeamName)) as Mix 
from Teams t1, Teams t2
where right(t1.TeamName, 1) = right(t2.TeamName, 1)
order by Mix

-- Problem 12.	Countries with International and Team Matches
select 
	c.CountryName as [Country Name], 
	count(distinct im1.Id) + count(distinct im2.Id) as [International Matches],
	count(distinct tm.Id) as [Team Matches]
from Countries c
left join InternationalMatches im1 on c.CountryCode = im1.HomeCountryCode
left join InternationalMatches im2 on c.CountryCode = im2.AwayCountryCode
left join Leagues l on c.CountryCode = l.CountryCode
left join TeamMatches tm on l.Id = tm.LeagueId
group by c.CountryName
having (count(distinct im1.Id) + count(distinct im2.Id)) > 0 or count(distinct tm.Id) > 0
order by [International Matches] desc, [Team Matches] desc, c.CountryName

-- Problem 13.	Non-international Matches
create table FriendlyMatches(
	Id int Identity primary key not null,
	HomeTeamID int not null,
	AwayTeamId int not null,
	MatchDate datetime not null
)
go

alter table FriendlyMatches
add constraint FK_FriendlyMatches_Teams_HomeTeam foreign key(HomeTeamId) references Teams(Id)
go

alter table FriendlyMatches
add constraint FK_FriendlyMatches_Teams_AwayTeam foreign key(AwayTeamId) references Teams(Id)
go

-- 2
INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO

-- 3
select
	t1.TeamName as [Home Team],
	t2.TeamName as [Away Team],
	fm.MatchDate as [Match Date]
from FriendlyMatches fm
join Teams t1 on fm.HomeTeamId = t1.Id
join Teams t2 on fm.AwayTeamId = t2.Id
union
select
	t1.TeamName as [Home Team],
	t2.TeamName as [Away Team],
	tm.MatchDate as [Match Date]
from TeamMatches tm
join Teams t1 on tm.HomeTeamID = t1.Id
join Teams t2 on tm.AwayTeamId = t2.Id
order by [Match Date] desc

-- Problem 14.	Seasonal Matches
alter table Leagues 
add IsSeasonal bit not null
default 0

-- 2 & 3
insert into TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId)
	values((select Id from Teams where TeamName = 'Empoli'),
		(select Id from Teams where TeamName = 'Parma'),
		2, 2, '19-Apr-2015 16:00',
		(select Id from Leagues where LeagueName = 'Italian Serie A')),
		((select Id from Teams where TeamName = 'Internazionale'),
		(select Id from Teams where TeamName = 'AC Milan'),
		0, 0, '19-Apr-2015 21:45',
		(select Id from Leagues where LeagueName = 'Italian Serie A'))
go

-- 4
update Leagues
set IsSeasonal = 1
where Id in(
	select l.Id from Leagues l 
	join TeamMatches tm on l.Id = tm.LeagueId
	group by l.Id
	having count(tm.Id) > 0
)

-- 5
select 
	t1.TeamName as [Home Team],
	tm.HomeGoals as [Home Goals],
	t2.TeamName as [Away Team],
	tm.AwayGoals as [Away Goals],
	l.LeagueName as [League Name]
from TeamMatches tm
join Leagues l on tm.LeagueId = l.Id
join Teams t1 on tm.HomeTeamId = t1.Id
join Teams t2 on tm.AwayTeamId = t2.Id
where tm.MatchDate > '10-Apr-2015'
order by [League Name], [Home Goals] desc, [Away Goals] desc

-- Problem 15.	Stored Function: Bulgarian Teams with Matches JSON
if object_id('fn_TeamsJSON') is not null
	drop function fn_TeamsJSON
go

create function fn_TeamsJSON()
	returns nvarchar(max)
as
begin
	declare @json nvarchar(max) = '{"teams":['

	declare teamsCursor cursor for
	select Id, TeamName from Teams
	where CountryCode = 'BG'
	order by TeamName

	open teamsCursor
	declare @TeamName nvarchar(max)
	declare @TeamId int
	fetch next from teamsCursor into @TeamId, @TeamName
	while @@fetch_status = 0
	begin
		set @json = @json + '{"name":"' + @TeamName + '","matches":['

		declare matchesCursor cursor for
		select t1.TeamName, t2.TeamName, HomeGoals, AwayGoals, MatchDate from TeamMatches
		left join Teams t1 on t1.Id = HomeTeamId
		left join Teams t2 on t2.Id = AwayTeamId
		where HomeTeamId = @TeamId or AwayTeamId = @TeamId
		order by TeamMatches.MatchDate desc

		open matchesCursor
		declare @HomeTeamName nvarchar(max)
		declare @AwayTeamName nvarchar(max)
		declare @HomeGoals int
		declare @AwayGoals int
		declare @MatchDate date
		fetch next from matchesCursor into @HomeTeamName, @AwayTeamName, @HomeGoals, @AwayGoals, @MatchDate
		while @@fetch_status = 0
		begin
			set @json = @json + '{"' + @HomeTeamName + '":' + convert(nvarchar(max), @HomeGoals) + ',"' + 
						@AwayTeamName + '":' + convert(nvarchar(max), @AwayGoals) + 
						',"date":' + convert(nvarchar(max), @MatchDate, 103) + '}'
			fetch next from matchesCursor into @HomeTeamName, @AwayTeamName, @HomeGoals, @AwayGoals, @MatchDate
			if @@fetch_status = 0
				set @json = @json + ','
		end
		close matchesCursor
		deallocate matchesCursor
		set @json = @json + ']}'

		fetch next from teamsCursor into @TeamId, @TeamName
		if @@fetch_status = 0
			set @json = @json + ','
	end
	close teamsCursor
	deallocate teamsCursor

	set @json = @json + ']}'
	return @json
end
go

SELECT dbo.fn_TeamsJSON()