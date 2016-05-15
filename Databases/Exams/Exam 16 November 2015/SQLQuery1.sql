-- 1: Album’s Name and Description
select Name, ISNULL(Description, 'No description') as Description from Albums
order by Name

-- 2: Photographs and Albums
select p.Title, a.Name from Photographs p
join AlbumsPhotographs ap on p.Id = ap.PhotographId
join Albums a on ap.AlbumId = a.Id
order by a.Name, p.Title desc

-- 3: Photographs with Category and Author
select Title, Link, Description, c.Name as CategoryName, u.FullName as Author from Photographs p
join Categories c on p.CategoryId = c.Id
join Users u on p.UserId = u.Id
where p.Description is not null
order by Title

-- 4: Users Born in January
select u.Username, u.FullName, u.BirthDate, ISNULL(p.Title, 'No photos') as Photo from Users u
left join Photographs p on u.Id = p.UserId
where MONTH(BirthDate) = 01
order by FullName

-- 5: Photographs with Equipment
select p.Title, c.Model as CameraModel, l.Model as LensModel from Photographs p
join Equipments e on p.EquipmentId = e.Id
join Cameras c on e.CameraId = c.Id
join Lenses l on e.LensId = l.Id
order by Title

-- 6: *Most Expensive Photos
select 
	p.Title, 
	cat.Name as [Category Name], 
	c.Model, 
	m.Name as [Manufacturer Name], 
	c.Megapixels,
	c.Price
from Categories cat
join Photographs p on cat.Id = p.CategoryId
join Equipments e on p.EquipmentId = e.Id
join Cameras c on e.CameraId = c.Id
join Manufacturers m on c.ManufacturerId = m.Id
order by c.Price desc, p.Title

where c.Price = (select MAX(c.Price) from Categories cat
join Photographs p on cat.Id = p.CategoryId
join Equipments e on p.EquipmentId = e.Id
join Cameras c on e.CameraId = c.Id)
order by c.Price desc, p.Title

-- 7: Price Larger Than Average
select m.Name, c.Model, c.Price from Manufacturers m
join Cameras c on m.Id = c.ManufacturerId
where c.Price > (select AVG(c.Price) from Manufacturers m
	join Cameras c on m.Id = c.ManufacturerId)
order by c.Price desc, c.Model

-- 8: Total Price of Lenses
select m.Name, SUM(l.Price) as [Total Price] from Manufacturers m
join Lenses l on m.Id = l.ManufacturerId
group by m.Name
order by Name

-- 9: Users with Old Cameras
select u.FullName, m.Name as Manufacturer, c.Model as [Camera Model], c.Megapixels from Users u
join Equipments e on u.EquipmentId = e.Id
join Cameras c on e.CameraId = c.Id
join Manufacturers m on c.ManufacturerId = m.Id
where c.Year < 2015
order by FullName

-- 10: Lenses per Type
select Type, COUNT(Type) as Count from Lenses
group by Type
order by Count desc, Type

-- 11: Sort Users
select Username, FullName from Users
order by LEN(Username + FullName), BirthDate desc

-- 12: Manufacturers without Products
select m.Name from Manufacturers m
left join Cameras c on m.Id = c.ManufacturerId
left join Lenses l on m.Id = l.ManufacturerId
where c.Model is NULL and l.Model is NULL
order by Name

-- 13: Cameras rise!
declare @nameLength int = (select LEN(Name) from Manufacturers) / 100
update Cameras
set Price = Price + ((select AVG(Price) from Cameras
	where ManufacturerId = (select c.ManufacturerId from Cameras c
		join Manufacturers m on c.ManufacturerId = m.Id))) 
		* (select LEN(Name) from Manufacturers) / 100

select Model, Price, ManufacturerId from Cameras
order by ManufacturerId, Price, Model





-- 15: Stored procedure for creating equipment