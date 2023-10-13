--Problem 09: Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName 
AS
	SELECT 
		CONCAT_WS(' ',FirstName, LastName) AS [Full Name]
	FROM AccountHolders

EXEC usp_GetHoldersFullName


--Problem 10: People with Balance Higher Than
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
	SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
	FROM AccountHolders AS ah
	LEFT JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.Id, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @number
	ORDER BY FirstName, LastName

--Second way with Subquery
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
	SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
	FROM AccountHolders AS ah
	WHERE ah.Id IN(
					SELECT AccountHolderId
					FROM Accounts
					GROUP BY AccountHolderId
					HAVING SUM(Balance) > @number
					)
	ORDER BY ah.FirstName, ah.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 10000


--Problem 11: Future Value Function
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18,2), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(20, 4)
AS
BEGIN 
	RETURN @Sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.10, 5)


--Problem 12: Calculate interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
	DECLARE @Years INT = 5

	SELECT
		a.Id AS [Account Id], ah.FirstName AS [First Name], ah.LastName AS [Last Name],
		a.Balance AS [Current Balance], dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, @Years) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1


