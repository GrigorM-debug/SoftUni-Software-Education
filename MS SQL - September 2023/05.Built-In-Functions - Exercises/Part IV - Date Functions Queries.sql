<<<<<<< HEAD
--Probelm 18: Orders table
SELECT ProductName, OrderDate, 
	DATEADD(day, 3, OrderDate) AS [Pay Due],
	DATEADD(month, 1, OrderDate) AS [Deliver Due]
FROM Orders

--Problem 19: People Table
CREATE TABLE People
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATE NOT NULL,
)

INSERT INTO [People] VALUES
	('Victor', '2000-12-07'),
	('Steven','1992-09-10'),
	('Stephen','1910-09-19'),
	('John','2010-01-06')

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
       DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
=======
--Probelm 18: Orders table
SELECT ProductName, OrderDate, 
	DATEADD(day, 3, OrderDate) AS [Pay Due],
	DATEADD(month, 1, OrderDate) AS [Deliver Due]
FROM Orders

--Problem 19: People Table
CREATE TABLE People
(
    Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATE NOT NULL,
)

INSERT INTO [People] VALUES
	('Victor', '2000-12-07'),
	('Steven','1992-09-10'),
	('Stephen','1910-09-19'),
	('John','2010-01-06')

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
       DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
FROM People