<<<<<<< HEAD
SELECT
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate, AdultsCount, ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
ORDER BY r.Price DESC, ArrivalDate ASC

SELECT
	h.Id, h.Name
FROM Hotels AS h
LEFT JOIN Bookings AS b ON b.HotelId = h.Id
JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
JOIN Rooms AS r ON r.Id = hr.RoomId
GROUP BY h.Name, r.Type, h.Id
HAVING  r.[Type] = 'VIP Apartment'
ORDER BY (
			SELECT COUNT(*) FROM Bookings
			WHERE HotelId = h.Id
		) DESC

SELECT 
	t.Id, t.Name, t.PhoneNumber
FROM Tourists AS t
LEFT JOIN Bookings AS b ON t.Id = b.TouristId
WHERE b.TouristId IS NULL
ORDER BY t.Name ASC

SELECT TOP(10)
	h.Name AS HotelName, d.Name AS DestinationName, c.Name AS CoiuntryName
FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
Join Destinations AS d ON d.Id = h.DestinationId
JOIN Countries AS c ON c.Id = d.CountryId
WHERE FORMAT(ArrivalDate, 'yyyy-MM-dd') < '2023-12-31' AND h.Id % 2 != 0
ORDER BY CoiuntryName ASC, b.ArrivalDate ASC

SELECT 
	h.Name AS HotelName, r.Price AS RoomPrice
FROM Tourists AS t
JOIN Bookings AS b ON t.Id = b.TouristId
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
WHERE t.Name NOT LIKE '%EZ'
ORDER BY RoomPrice DESC 

SELECT
	h.Name AS HotelName, SUM(r.Price * DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate)) AS HotelRevenue
FROM Bookings AS b
LEFT JOIN Hotels AS h ON b.HotelId = h.Id
JOIN Rooms AS r ON r.Id = b.RoomId
GROUP BY h.Name 
ORDER BY HotelRevenue DESC

=======
SELECT
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate, AdultsCount, ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
ORDER BY r.Price DESC, ArrivalDate ASC

SELECT
	h.Id, h.Name
FROM Hotels AS h
LEFT JOIN Bookings AS b ON b.HotelId = h.Id
JOIN HotelsRooms AS hr ON hr.HotelId = h.Id
JOIN Rooms AS r ON r.Id = hr.RoomId
GROUP BY h.Name, r.Type, h.Id
HAVING  r.[Type] = 'VIP Apartment'
ORDER BY (
			SELECT COUNT(*) FROM Bookings
			WHERE HotelId = h.Id
		) DESC

SELECT 
	t.Id, t.Name, t.PhoneNumber
FROM Tourists AS t
LEFT JOIN Bookings AS b ON t.Id = b.TouristId
WHERE b.TouristId IS NULL
ORDER BY t.Name ASC

SELECT TOP(10)
	h.Name AS HotelName, d.Name AS DestinationName, c.Name AS CoiuntryName
FROM Bookings AS b
JOIN Hotels AS h ON h.Id = b.HotelId
Join Destinations AS d ON d.Id = h.DestinationId
JOIN Countries AS c ON c.Id = d.CountryId
WHERE FORMAT(ArrivalDate, 'yyyy-MM-dd') < '2023-12-31' AND h.Id % 2 != 0
ORDER BY CoiuntryName ASC, b.ArrivalDate ASC

SELECT 
	h.Name AS HotelName, r.Price AS RoomPrice
FROM Tourists AS t
JOIN Bookings AS b ON t.Id = b.TouristId
JOIN Hotels AS h ON h.Id = b.HotelId
JOIN Rooms AS r ON r.Id = b.RoomId
WHERE t.Name NOT LIKE '%EZ'
ORDER BY RoomPrice DESC 

SELECT
	h.Name AS HotelName, SUM(r.Price * DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate)) AS HotelRevenue
FROM Bookings AS b
LEFT JOIN Hotels AS h ON b.HotelId = h.Id
JOIN Rooms AS r ON r.Id = b.RoomId
GROUP BY h.Name 
ORDER BY HotelRevenue DESC

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
