<<<<<<< HEAD
USE Boardgames

SELECT [Name], Rating 
FROM Boardgames
ORDER BY YearPublished ASC, [Name] DESC

SELECT 
    b.Id, b.Name, b.YearPublished, c.Name AS [Category Name]
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryID = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC

SELECT 
    c.Id, CONCAT_WS(' ', c.FirstName, c.LastName) AS CreatorName,
    c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardGames As cb ON cb.CreatorId = c.Id
WHERE cb.CreatorId IS NULL
ORDER BY CreatorName ASC

SELECT TOP(5)
    b.[Name], Rating, c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges As pg ON pg.Id = b.PlayersRangeId
WHERE b.Rating > 7.00 AND b.Name LIKE '%a%' OR b.Rating > 7.50 AND pg.PlayersMin = 2 AND pg.PlayersMax = 5
ORDER BY b.Name ASC, b.Rating DESC


SELECT
    CONCAT_WS(' ', c.FirstName, c.LastName) AS [FullName],
    c.Email, MAX(b.Rating)
FROM Creators AS c
JOIN CreatorsBoardGames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
GROUP BY CONCAT_WS(' ', c.FirstName, c.LastName), c.Email
HAVING c.Email LIKE '%.com'
ORDER BY CONCAT_WS(' ', c.FirstName, c.LastName) ASC

SELECT 
    c.LastName, CAST(CEILING(AVG(b.Rating))AS INT) AS [AverageRating],
    p.Name AS [PublisherName]
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p ON p.Id = b.PublisherId
GROUP BY c.LastName, p.Name
HAVING p.Name = 'Stonemaier Games'
=======
USE Boardgames

SELECT [Name], Rating 
FROM Boardgames
ORDER BY YearPublished ASC, [Name] DESC

SELECT 
    b.Id, b.Name, b.YearPublished, c.Name AS [Category Name]
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryID = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC

SELECT 
    c.Id, CONCAT_WS(' ', c.FirstName, c.LastName) AS CreatorName,
    c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardGames As cb ON cb.CreatorId = c.Id
WHERE cb.CreatorId IS NULL
ORDER BY CreatorName ASC

SELECT TOP(5)
    b.[Name], Rating, c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges As pg ON pg.Id = b.PlayersRangeId
WHERE b.Rating > 7.00 AND b.Name LIKE '%a%' OR b.Rating > 7.50 AND pg.PlayersMin = 2 AND pg.PlayersMax = 5
ORDER BY b.Name ASC, b.Rating DESC


SELECT
    CONCAT_WS(' ', c.FirstName, c.LastName) AS [FullName],
    c.Email, MAX(b.Rating)
FROM Creators AS c
JOIN CreatorsBoardGames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
GROUP BY CONCAT_WS(' ', c.FirstName, c.LastName), c.Email
HAVING c.Email LIKE '%.com'
ORDER BY CONCAT_WS(' ', c.FirstName, c.LastName) ASC

SELECT 
    c.LastName, CAST(CEILING(AVG(b.Rating))AS INT) AS [AverageRating],
    p.Name AS [PublisherName]
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p ON p.Id = b.PublisherId
GROUP BY c.LastName, p.Name
HAVING p.Name = 'Stonemaier Games'
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
ORDER BY AVG(b.Rating) DESC