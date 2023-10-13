--Problem 01: Employees with Salary above 35000
CREATE OR ALTER PROC ups_GetEmployeesSalaryAbove35000
AS
	SELECT 
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE Salary > 35000

EXEC ups_GetEmployeesSalaryAbove35000

--Problem 02: Employees with Salary above number
CREATE OR ALTER PROCEDURE ups_GetEmployeesSalaryAboveNumber (@number DECIMAL(18,4))
AS
	SELECT 
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @number


EXEC ups_GetEmployeesSalaryAboveNumber 48100

--Problem 03: Town Names starting with 
CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith (@string VARCHAR(50))
AS
	SELECT
		[Name] AS [Town]
	FROM Towns
	WHERE Name LIKE(@string) + '%'

EXEC usp_GetTownsStartingWith 'b'

--Problem 04: Employees from Town
CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown (@town VARCHAR(50))
AS 
	SELECT 
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.Name = @town

EXEC usp_GetEmployeesFromTown 'Sofia'

--Problem 05: Salary Level Function
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(50)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(20)
	If(@salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF (@salary BETWEEN 30000 AND 50000)
		SET @salaryLevel = 'Average'
	ELSE
		SET @salaryLevel = 'High'
	RETURN @salaryLevel
END

SELECT 
	Salary
	,dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees

--Problem 06: Employees by Salary level
CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel  (@level VARCHAR(50))
AS
	SELECT
		FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @level

EXEC usp_EmployeesBySalaryLevel 'High'


--Problem 07: Define Function
CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	WHILE (@counter <= LEN(@word))
	BEGIN		
		IF @setOfLetters NOT LIKE '%' + SUBSTRING(@word, @counter, 1) + '%' RETURN 0
		SET @counter += 1
	END
	RETURN 1
END

--Problem 08: Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment  (@departmentId INT)
AS 
BEGIN 
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
	(
		SELECT EmployeeID 
		FROM Employees 
		WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN
	(
		SELECT EmployeeID 
		FROM Employees
		WHERE DepartmentID = @departmentId
	)

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 2 -- I didn't execute it because I don't want to delete my tables


