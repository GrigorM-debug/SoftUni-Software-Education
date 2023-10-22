<<<<<<< HEAD
USE SoftUniSecondDb;

--Problem 01: Find names of all Employees by FirstName
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%';

--Problem 02: Find names of all Employees by LastName
SELECT FirstName, LastName
FROM Employees
WHERE LastName Like '%ei%';

--Problem 03: Find FirstNasme of all Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10)
AND HireDate BETWEEN '1995-01-01' AND '2005-01-01';

--Second way to for Problem 03
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
  AND YEAR(HireDate) BETWEEN 1995 AND 2005;

--Problem 04: Find all Employees Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--Problem 05: Find Towns with Name Lenght
SELECT Name
FROM Towns
WHERE DATALENGTH(Name) IN (5, 6)
ORDER BY Name;

--Problem 06: Find Towns starting with
SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name ASC

--Second way for Problem 06
SELECT TownID, Name
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name ASC


--Problem 07: Find Towns Not starting with
SELECT TownID, Name
FROM Towns
WHERE Name NOT LIKE('[RBD]%')
ORDER BY Name

--Second way to do the Problem 07
SELECT TownId, Name
FROM Towns
WHERE LEFT(Name, 1)  NOT IN ('R', 'B', 'D')
ORDER BY Name

--Problem 08: Create View Employees hired after 2000 year
CREATE VIEW [V_EmployeesHiredAfter2000] AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE YEAR(HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

--Problem 09: Length of LastName
SELECT FirstName, LastName
FROM Employees
WHERE DATALENGTH(LastName) = 5

--Problem 10: Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--Problem 11: Find all Employees with Rank 2
SELECT * FROM 
	(SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000) AS Subquery
WHERE Subquery.Rank = 2
ORDER BY Salary DESC
=======
USE SoftUniSecondDb;

--Problem 01: Find names of all Employees by FirstName
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%';

--Problem 02: Find names of all Employees by LastName
SELECT FirstName, LastName
FROM Employees
WHERE LastName Like '%ei%';

--Problem 03: Find FirstNasme of all Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3, 10)
AND HireDate BETWEEN '1995-01-01' AND '2005-01-01';

--Second way to for Problem 03
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
  AND YEAR(HireDate) BETWEEN 1995 AND 2005;

--Problem 04: Find all Employees Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--Problem 05: Find Towns with Name Lenght
SELECT Name
FROM Towns
WHERE DATALENGTH(Name) IN (5, 6)
ORDER BY Name;

--Problem 06: Find Towns starting with
SELECT TownID, Name
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name ASC

--Second way for Problem 06
SELECT TownID, Name
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name ASC


--Problem 07: Find Towns Not starting with
SELECT TownID, Name
FROM Towns
WHERE Name NOT LIKE('[RBD]%')
ORDER BY Name

--Second way to do the Problem 07
SELECT TownId, Name
FROM Towns
WHERE LEFT(Name, 1)  NOT IN ('R', 'B', 'D')
ORDER BY Name

--Problem 08: Create View Employees hired after 2000 year
CREATE VIEW [V_EmployeesHiredAfter2000] AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE YEAR(HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

--Problem 09: Length of LastName
SELECT FirstName, LastName
FROM Employees
WHERE DATALENGTH(LastName) = 5

--Problem 10: Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--Problem 11: Find all Employees with Rank 2
SELECT * FROM 
	(SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000) AS Subquery
WHERE Subquery.Rank = 2
ORDER BY Salary DESC
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
