<<<<<<< HEAD
--Problem 13: Scalar function: Cash in User Games Odd Rows
CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100))
RETURNS @result TABLE(
	SumCash MONEY NOT NULL) AS
BEGIN
	WITH Games_CTE
	AS
	(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber,
		SUM(ug.Cash) AS SumCash
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
    WHERE g.[Name] = @gameName
    GROUP BY g.Id, ug.Cash
	)

	INSERT INTO @result SELECT SumCash FROM Games_CTE
						WHERE RowNumber % 2 = 1

	RETURN
END

SELECT SumCash FROM ufn_CashInUsersGames('Love in a mist')

--Second way with Subquery because Judge didn't like the first one with CTE
CREATE OR ALTER FUNCTION ufn_CashInUsersGames2(@gameName VARCHAR(100))
RETURNS TABLE
AS
	RETURN SELECT SUM(Cash) AS SumCash
	FROM
	(
	SELECT 
		ug.Cash,
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
    WHERE g.[Name] = @gameName
    GROUP BY g.Id, ug.Cash
	) AS subquery

	WHERE subquery.RowNumber %2 =1

=======
--Problem 13: Scalar function: Cash in User Games Odd Rows
CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100))
RETURNS @result TABLE(
	SumCash MONEY NOT NULL) AS
BEGIN
	WITH Games_CTE
	AS
	(
	SELECT 
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber,
		SUM(ug.Cash) AS SumCash
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
    WHERE g.[Name] = @gameName
    GROUP BY g.Id, ug.Cash
	)

	INSERT INTO @result SELECT SumCash FROM Games_CTE
						WHERE RowNumber % 2 = 1

	RETURN
END

SELECT SumCash FROM ufn_CashInUsersGames('Love in a mist')

--Second way with Subquery because Judge didn't like the first one with CTE
CREATE OR ALTER FUNCTION ufn_CashInUsersGames2(@gameName VARCHAR(100))
RETURNS TABLE
AS
	RETURN SELECT SUM(Cash) AS SumCash
	FROM
	(
	SELECT 
		ug.Cash,
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
	FROM Games AS g
	JOIN UsersGames AS ug ON ug.GameId = g.Id
    WHERE g.[Name] = @gameName
    GROUP BY g.Id, ug.Cash
	) AS subquery

	WHERE subquery.RowNumber %2 =1

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
SELECT SumCash FROM ufn_CashInUsersGames2('Love in a mist')