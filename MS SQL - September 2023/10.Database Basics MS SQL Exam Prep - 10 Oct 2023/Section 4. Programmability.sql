--Problem 11: Product with Clients
CREATE OR ALTER FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
RETURNS INT
AS
BEGIN
    DECLARE @numberOfClients INT =
    (
        SELECT COUNT(*) FROM Clients AS c
        JOIN ProductsClients AS pc ON pc.ClientId = c.Id
        JOIN Products AS p ON pc.ProductId = p.Id
        WHERE p.Name = @name
    )

    RETURN @numberOfClients
END

SELECT dbo.udf_ProductWithClients('ivan')

--Problem 12: Search for Vendors from a specific Country
CREATE OR ALTER PROCEDURE usp_SearchByCountry(@country VARCHAR(10))
AS
    SELECT v.Name AS Vendor, v.NumberVAT AS VAT,
    CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Number],
    CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
    FROM Vendors AS v
    JOIN Addresses AS a ON v.AddressId = a.Id
    JOIN Countries AS c ON a.CountryId = c.Id
    WHERE c.Name = @country
    ORDER BY v.Name ASC, a.City ASC

EXEC usp_SearchByCountry 'France'