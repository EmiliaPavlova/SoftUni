use Geography

-- Problem 1.	All Mountain Peaks
select PeakName from Peaks
order by PeakName

-- Problem 2.	Biggest Countries by Populationd
select top 30 CountryName, Population from Countries
where ContinentCode = 'EU'
order by Population desc, CountryName

-- Problem 3.	Countries and Currency (Euro / Not Euro)
select CountryName, CountryCode, (case 
	when CurrencyCode = 'EUR' then 'Euro' 
	else 'Not Euro' end) as Currency
from Countries
order by CountryName

-- Problem 4.	Countries Holding 'A' 3 or More Times
select CountryName as [Country Name], IsoCode as [ISO Code] from Countries
where CountryName like '%a%a%a%'
order by IsoCode

-- Problem 5.	Peaks and Mountains
select p.PeakName, m.MountainRange as Mountain, p.Elevation from Peaks p
join Mountains m on p.MountainId = m.Id
order by p. Elevation desc, p. PeakName

-- Problem 6.	Peaks with Their Mountain, Country and Continent
select p.PeakName, m.MountainRange as Mountain, c.CountryName, cnt.ContinentName from Peaks p
join Mountains m on p.MountainId = m.Id
join MountainsCountries mc on m.Id = mc.MountainId
join Countries c on mc.CountryCode = c.CountryCode
join Continents cnt on c.ContinentCode = cnt.ContinentCode
order by p.PeakName, c.CountryName

-- Problem 7.	* Rivers Passing through 3 or More Countries
select RiverName as River, 
	(select count(distinct CountryCode) from CountriesRivers where RiverId = r.Id) as [Countries Count] from Rivers r
where (select count(distinct CountryCode) from CountriesRivers where RiverId = r.Id) >= 3
order by RiverName

-- Problem 8.	Highest, Lowest and Average Peak Elevation
select max(elevation) as MaxElevation, min(elevation) as MinElevation, avg(elevation) as AverageElevation from Peaks

-- Problem 9.	Rivers by Country
select c.CountryName, 
	cnt.ContinentName, 
	count(r.Id) as RiversCount, 
	isnull(sum(r.Length), 0) as TotalLength 
from Countries c
left join Continents cnt on c.ContinentCode = cnt.ContinentCode
left join CountriesRivers cr on c.CountryCode = cr.CountryCode
left join Rivers r on cr.RiverId = r.Id
group by c.CountryName, cnt.ContinentName
order by RiversCount desc, TotalLength desc, c.CountryName

-- Problem 10.	Count of Countries by Currency
select cr.CurrencyCode, min(cr.Description) as Currency, count(c.CountryName) as NumberOfCountries from Currencies cr
left join Countries c on cr.CurrencyCode = c.CurrencyCode
group by cr.CurrencyCode
order by NumberOfCountries desc, Currency

-- Problem 11.	* Population and Area by Continent
select cnt.ContinentName, 
	sum(convert(numeric, c.AreaInSqKm)) as CountriesArea, 
	sum(convert(numeric, c.Population)) as CountriesPopulation 
from Continents cnt
join Countries c on cnt.ContinentCode = c.ContinentCode
group by cnt.ContinentName
order by CountriesPopulation desc

-- Problem 12.	Highest Peak and Longest River by Country
select c.CountryName, max(p.Elevation) as HighestPeakElevation, max(r.Length) as LongestRiverLength from Countries c
left join MountainsCountries mc on c.CountryCode = mc.CountryCode
left join Mountains m on mc.MountainId = m.Id
left join Peaks p on m.Id = p.MountainId
left join CountriesRivers cr on c.CountryCode = cr.CountryCode
left join Rivers r on cr.RiverId = r.Id
group by c.CountryName
order by HighestPeakElevation desc, LongestRiverLength desc, c.CountryName

-- Problem 13.	Mix of Peak and River Names
select p.PeakName, 
	r.RiverName, 
	lower(p.PeakName + substring(r.RiverName, 2, len(r.RiverName))) as Mix 
from Peaks p, Rivers r
--join Mountains m on p.MountainId = m.Id
--join MountainsCountries mc on m.Id = mc.MountainId
--join Countries c on mc.CountryCode = c.CountryCode
--join CountriesRivers cr on c.CountryCode = cr.CountryCode
--join Rivers r on cr.RiverId = r.Id
where right(p.PeakName, 1) = left(r.RiverName, 1)
order by Mix

-- Problem 14.	** Highest Peak Name and Elevation by Country
select c.CountryName as Country, 
	p.PeakName AS [Highest Peak Name], 
	p.Elevation as [Highest Peak Elevation],
	m.MountainRange as Mountain 
from Countries c
left join MountainsCountries mc on c.CountryCode = mc.CountryCode
left join Mountains m on mc.MountainId = m.Id
left join Peaks p on m.Id = p.MountainId
where p.Elevation = (select max(p.Elevation) from MountainsCountries mc
	left join Mountains m on mc.MountainId = m.Id
	left join Peaks p on m.Id = p.MountainId
where c.CountryCode = mc.CountryCode)
union
select c.CountryName as Country, '(no highest peak)' as [Highest Peak Name],
	0 as [Highest Peak Elevation], '(no mountain)' as Mountain
from Countries c
left join MountainsCountries mc on c.CountryCode = mc.CountryCode
left join Mountains m on mc.MountainId = m.Id
left join Peaks p on m.Id = p.MountainId
where (select max(p.Elevation) from MountainsCountries mc
	left join Mountains m on mc.MountainId = m.Id
	left join Peaks p on m.Id = p.MountainId
where c.CountryCode = mc.CountryCode) is null
order by c.CountryName, [Highest Peak Name]

-- Problem 15.	Monasteries by Country
create table Monasteries(
	Id int identity primary key,
	Name nvarchar(50),
	CountryCode char(2)
)
go

alter table Monasteries add constraint FK_Monasteries_Countries
foreign key (CountryCode) references Countries(CountryCode)
go

-- 2
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

-- 3
alter table Countries add IsDeleted bit not null
default 0

-- 4
update Countries 
set IsDeleted = 1
where CountryCode in(
	select c.CountryCode
	from Countries c
		join CountriesRivers cr on c.CountryCode = cr.CountryCode
		join Rivers r on r.Id = cr.RiverId
	group by c.CountryCode
	having count(r.Id) > 3
)

-- 5
select m.Name as Monastery, c.CountryName as Country from Monasteries m
join Countries c on m.CountryCode = c.CountryCode
where c.IsDeleted = 0
order by Monastery

-- Problem 16.	Monasteries by Continents and Countries
update Countries 
set CountryName = 'Burma'
where CountryName = 'Myanmar'

-- 2
insert into Monasteries(Name, CountryCode)
	values ('Hanga Abbey', (select CountryCode from Countries where CountryName = 'Tanzania'))

-- 3
insert into Monasteries(Name, CountryCode)
	values ('Myin-Tin-Daik', (select CountryCode from Countries where CountryName = 'Myanmar'))

-- 4
select cnt.ContinentName, c.CountryName, count(m.CountryCode) as MonasteriesCount from Continents cnt
join Countries c on cnt.ContinentCode = c.ContinentCode
left join Monasteries m on c.CountryCode = m.CountryCode
where c.IsDeleted = 0
group by cnt.ContinentName, c.CountryName
order by MonasteriesCount desc, c.CountryName

-- Problem 17.	Stored Function: Mountain Peaks JSON
if object_id('fn_MountainsPeaksJSON') is not null
	drop function fn_MountainsPeaksJSON 
go

create function fn_MountainsPeaksJSON()
	returns nvarchar(max)
as
begin
	declare @json nvarchar(max) = '{"mountains":['

	declare mountainsCursor cursor for
	select Id, MountainRange from Mountains

	open mountainsCursor
	declare @mountainName nvarchar(max)
	declare @mountainId int
	fetch next from mountainsCursor into @mountainId, @mountainName
	while @@fetch_status = 0
	begin
		set @json = @json + '{"name":"' + @mountainName + '","peaks":['

		declare peaksCursor cursor for
		select Peakname, Elevation from Peaks
		where MountainId = @mountainId
	
		open peaksCursor
		declare @peakName nvarchar(max)
		declare @elevation int
		fetch next from peaksCursor into @peakName, @elevation
		while @@fetch_status = 0
		begin
			set @json = @json + '{"name":"' + @peakName + '",' + '"elevation":' + convert(nvarchar(max), @elevation) + '}'
			fetch next from peaksCursor into @peakName, @elevation
			if @@fetch_status = 0
				set @json = @json + ','
		end
		close peaksCursor
		deallocate peaksCursor
		set @json = @json + ']}'
		
		fetch next from mountainsCursor into @mountainId, @mountainName
		if @@fetch_status = 0
			set @json = @json + ','
	end
	close mountainsCursor
	deallocate mountainsCursor	
	
	set @json = @json + ']}'
	return @json
end
go			

SELECT dbo.fn_MountainsPeaksJSON()

-- Problem 18.	Design a Database Schema in MySQL and Write a Query
DROP DATABASE IF EXISTS `trainings`;

CREATE DATABASE `trainings` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `trainings`;

CREATE TABLE `training_centers` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description text,
    url NVARCHAR(2083));
    
CREATE TABLE `courses` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description text);
    
CREATE TABLE `timetable` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    course_id INT NOT NULL REFERENCES courses(id),
    training_center_id INT NOT NULL REFERENCES training_centers(id),
    start_date DATE NOT NULL);
    
-- Task 2
INSERT INTO `training_centers` VALUES 
	(1, 'Sofia Learning', NULL, 'http://sofialearning.org'), 
    (2, 'Varna Innovations & Learning', 'Innovative training center, located in Varna. Provides trainings in software development and foreign languages', 'http://vil.edu'), 
    (3, 'Plovdiv Trainings & Inspiration', NULL, NULL),
	(4, 'Sofia West Adult Trainings', 'The best training center in Lyulin', 'https://sofiawest.bg'), 
	(5, 'Software Trainings Ltd.', NULL, 'http://softtrain.eu'),
	(6, 'Polyglot Language School', 'English, French, Spanish and Russian language courses', NULL), 
    (7, 'Modern Dances Academy', 'Learn how to dance!', 'http://danceacademy.bg');

INSERT INTO `courses` VALUES 
	(101, 'Java Basics', 'Learn more at https://softuni.bg/courses/java-basics/'), 
    (102, 'English for beginners', '3-month English course'), 
    (103, 'Salsa: First Steps', NULL), 
    (104, 'Avancée Français', 'French language: Level III'), 
    (105, 'HTML & CSS', NULL), 
    (106, 'Databases', 'Introductionary course in databases, SQL, MySQL, SQL Server and MongoDB'), 
    (107, 'C# Programming', 'Intro C# corse for beginners'), 
    (108, 'Tango dances', NULL), 
    (109, 'Spanish, Level II', 'Aprender Español');

INSERT INTO `timetable`(course_id, training_center_id, start_date) VALUES 
	(101, 1, '2015-01-31'), (101, 5, '2015-02-28'), (102, 6, '2015-01-21'),
    (102, 4, '2015-01-07'), (102, 2, '2015-02-14'), (102, 1, '2015-03-05'),     
    (102, 3, '2015-03-01'), (103, 7, '2015-02-25'), (103, 3, '2015-02-19'),     
    (104, 5, '2015-01-07'), (104, 1, '2015-03-30'), (104, 3, '2015-04-01'), 
    (105, 5, '2015-01-25'), (105, 4, '2015-03-23'), (105, 3, '2015-04-17'),     
    (105, 2, '2015-03-19'), (106, 5, '2015-02-26'), (107, 2, '2015-02-20'), 
    (107, 1, '2015-01-20'), (107, 3, '2015-03-01'), (109, 6, '2015-01-13');

UPDATE `timetable` t JOIN `courses` c ON t.course_id = c.id
SET t.start_date = DATE_SUB(t.start_date, INTERVAL 7 DAY)
WHERE c.name REGEXP '^[a-j]{1,5}.*s$';

SELECT
	tc.name AS `traning center`,
    DATE(t.start_date) AS `start date`,
    c.name AS `course name`,
    IFNULL(c.description, 'NULL') as `more info`
FROM timetable AS t
JOIN training_centers AS tc
	ON t.training_center_id = tc.id
JOIN courses AS c
	ON t.course_id = c.id
ORDER BY t.start_date ASC, t.id ASC;