<<<<<<< HEAD
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @numberOfGames INT =
    (
        SELECT 
            COUNT(*)
        FROM Boardgames AS b
        JOIN CreatorsBoardGames AS cb ON cb.BoardgameId = b.Id
        JOIN Creators AS c ON c.Id = cb.CreatorId
        WHERE c.FirstName = @name
    )

    RETURN @numberOfGames
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
    SELECT 
        b.Name, b.YearPublished, b.Rating, c.Name AS CategoryName,
        p.Name AS PublisherName, CONCAT(pg.PlayersMin, ' ', 'people') AS MinPlayers,
        CONCAT(pg.PlayersMax, ' ', 'people') AS MaxPlayers
    FROM Boardgames AS b
    JOIN Categories AS c ON b.CategoryId = c.Id
    JOIN PlayersRanges AS pg ON b.PlayersRangeId = pg.Id
    JOIN Publishers AS p ON b.PublisherId = p.Id
    WHERE c.Name = @category
    ORDER BY p.Name ASC, b.YearPublished DESC

=======
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @numberOfGames INT =
    (
        SELECT 
            COUNT(*)
        FROM Boardgames AS b
        JOIN CreatorsBoardGames AS cb ON cb.BoardgameId = b.Id
        JOIN Creators AS c ON c.Id = cb.CreatorId
        WHERE c.FirstName = @name
    )

    RETURN @numberOfGames
END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
    SELECT 
        b.Name, b.YearPublished, b.Rating, c.Name AS CategoryName,
        p.Name AS PublisherName, CONCAT(pg.PlayersMin, ' ', 'people') AS MinPlayers,
        CONCAT(pg.PlayersMax, ' ', 'people') AS MaxPlayers
    FROM Boardgames AS b
    JOIN Categories AS c ON b.CategoryId = c.Id
    JOIN PlayersRanges AS pg ON b.PlayersRangeId = pg.Id
    JOIN Publishers AS p ON b.PublisherId = p.Id
    WHERE c.Name = @category
    ORDER BY p.Name ASC, b.YearPublished DESC

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
EXEC usp_SearchByCategory 'Wargames'