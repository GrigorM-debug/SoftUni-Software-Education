<<<<<<< HEAD
CREATE PROCEDURE usp_SearchByCountry(@country NVARCHAR(50)) 
AS
	SELECT
		t.Name, t.PhoneNumber, t.Email, COUNT(b.TouristId) AS CountOfBookings
	FROM Tourists AS t
	JOIN Countries AS c On t.CountryId = c.Id
	JOIN Bookings AS b ON b.TouristId = t.Id
	GROUP BY t.Name, c.Name, t.PhoneNumber, t.Email
	HAVING c.Name = @country
	ORDER BY t.Name ASC, COUNT(b.TouristId) DESC

EXEC usp_SearchByCountry 'Greece'

CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS 
BEGIN
	DECLARE @countOfTourist INT =
	(
		SELECT 
			SUM(b.AdultsCount + b.ChildrenCount)
		FROM Tourists AS t
		JOIN Bookings AS b ON t.Id = b.TouristId
		JOIN Rooms AS r ON r.Id = b.RoomId
		WHERE r.Type = @name
	)

	RETURN @countOfTourist
END

=======
CREATE PROCEDURE usp_SearchByCountry(@country NVARCHAR(50)) 
AS
	SELECT
		t.Name, t.PhoneNumber, t.Email, COUNT(b.TouristId) AS CountOfBookings
	FROM Tourists AS t
	JOIN Countries AS c On t.CountryId = c.Id
	JOIN Bookings AS b ON b.TouristId = t.Id
	GROUP BY t.Name, c.Name, t.PhoneNumber, t.Email
	HAVING c.Name = @country
	ORDER BY t.Name ASC, COUNT(b.TouristId) DESC

EXEC usp_SearchByCountry 'Greece'

CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS 
BEGIN
	DECLARE @countOfTourist INT =
	(
		SELECT 
			SUM(b.AdultsCount + b.ChildrenCount)
		FROM Tourists AS t
		JOIN Bookings AS b ON t.Id = b.TouristId
		JOIN Rooms AS r ON r.Id = b.RoomId
		WHERE r.Type = @name
	)

	RETURN @countOfTourist
END

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
SELECT dbo.udf_RoomsWithTourists('Double Room')