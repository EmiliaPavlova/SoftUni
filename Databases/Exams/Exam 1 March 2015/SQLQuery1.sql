-- Problem 1.	All Mountain Peaks
SELECT PeakName FROM Peaks
order by PeakName

-- Problem 2.	Biggest Countries by Population
select top 30 CountryName, [Population] from Countries
where ContinentCode = 'EU'
order by Population desc

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
join Mountains m on m.Id = p.MountainId
order by Elevation desc, PeakName

-- Problem 6.	Peaks with Their Mountain, Country and Continent
select p.PeakName, m.MountainRange as Mountain, c.CountryName, cn.ContinentName from Peaks p
join Mountains m on m.Id = p.MountainId
join MountainsCountries mc on m.Id = mc.MountainId
join Countries c on mc.CountryCode = c.CountryCode
join Continents cn on c.ContinentCode = cn.ContinentCode
order by PeakName, CountryName

-- Problem 7.	* Rivers Passing through 3 or More Countries
select RiverName as River, 
	(select count(distinct CountryCode) from CountriesRivers 
	where RiverId = r.Id) as [Countries Count] from Rivers r
where (select count(distinct CountryCode) from CountriesRivers where RiverId = r.Id) >= 3
order by RiverName

-- Problem 8.	Highest, Lowest and Average Peak Elevation
select max(elevation) as MaxElevation, min(Elevation) as MinElevation, avg(Elevation) as AverageElevation from Peaks

-- Problem 9.	Rivers by Country
select c.CountryName, 
	con.ContinentName, 
	count(r.Id) as RiversCount, 
	isnull(sum(r.Length), 0) as TotalLength 
from Countries c
left join Continents con on con.ContinentCode = c.ContinentCode
left join CountriesRivers cr on cr.CountryCode = c.CountryCode
left join Rivers r on r.Id = cr.RiverId
group by c.CountryName, con.ContinentName
order by RiversCount desc, TotalLength desc, CountryName

-- Problem 10.	Count of Countries by Currency
select cr.CurrencyCode, min(cr.Description) as Currency, count(c.CountryName) as NumberOfCountries from Currencies cr
left join Countries c on cr.CurrencyCode = c.CurrencyCode
group by cr.CurrencyCode
order by NumberOfCountries desc, Currency

-- Problem 11.	Population and Area by Continent
select con.ContinentName,
	sum(convert(numeric, c.AreaInSqKm)) as CountriesArea,
	sum(convert(numeric, c.Population)) as CountriesPopulation 
from Continents con
join Countries c on con.ContinentCode = c.ContinentCode
group by con.ContinentName
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


-- Problem 16.	Monasteries by Continents and Countries


-- Problem 17.	Stored Function: Mountain Peaks JSON


-- Problem 18.	Design a Database Schema in MySQL and Write a Query