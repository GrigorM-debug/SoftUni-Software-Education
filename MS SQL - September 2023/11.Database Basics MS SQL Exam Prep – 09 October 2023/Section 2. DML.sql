INSERT INTO Boardgames([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
    ('Deep Blue', 2019, 5.67, 1, 2, 7),
    ('Paris', 2016, 9.78, 5, 1, 4),
    ('Catan: Starfarers', 2021, 9.87, 4, 4, 3),
    ('Bleeding Kansas', 2020, 3.25, 3, 3, 2),
    ('One Small Step', 2019, 5.75, 5, 5, 1);

INSERT INTO Publishers([Name], AddressId, Website, Phone)
VALUES
    ('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
    ('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
    ('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');


UPDATE PlayersRanges
SET PlayersMax += 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET Name = CONCAT(Name, 'V2')
WHERE YearPublished >= 2020

CREATE TABLE TempTableWithAddresses
(
    Id INT IDENTITY PRIMARY KEY,
    AddressId INT
)

INSERT INTO TempTableWithAddresses(AddressId)
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%'

DECLARE @addressToRemove INT = 
(
	SELECT
    AddressId
    FROM TempTableWithAddresses
    WHERE Id = 1
)

DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN
(
	SELECT b.Id
    FROM Boardgames AS b
    LEFT JOIN Publishers AS p ON p.Id = b.PublisherId
    WHERE p.AddressId IN (@addressToRemove)
)

DELETE FROM Boardgames
WHERE PublisherId IN
(
	SELECT Id
	FROM Publishers
	WHERE AddressId IN (@addressToRemove)
)

DELETE FROM Publishers
WHERE AddressId IN (@addressToRemove)

DELETE FROM Addresses
WHERE Id IN (@addressToRemove)