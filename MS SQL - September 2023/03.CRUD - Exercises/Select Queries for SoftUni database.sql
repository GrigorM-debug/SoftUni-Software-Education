USE SoftUniSecondDb

--Problem 01: Find all the information about Departments
SELECT * FROM Departments

--Problem 02: Find all Department Names
SELECT [Name] FROM Departments

--Problem 03: Find Salary of each Employee
SELECT FirstName, LastName, Salary FROM Employees

--Problem 04: Find Full Name of each employee
SELECT FirstName, MiddleName, LastName FROM Employees

--Problem 05: Find Email address of each Employee
SELECT (FirstName + '.' + LastName + '@softuni.bg') AS [Full Email Address]FROM Employees

--Problem 06: Find all diffrent Employees' Salaries
SELECT DISTINCT Salary FROM Employees

--Problem 07: Find all information about Employees
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

--Problem 08: Find names of all Employees by Salary in range
SELECT FirstName, LastName, JobTitle FROM Employees WHERE Salary BETWEEN 20000 AND 30000

--Problem 09: Find names of all Employees
SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Full Name] 
FROM Employees
WHERE Salary IN(25000, 14000, 12500, 23600)

--Problem 10: Find all employees without manager
SELECT FirstName, LastName FROM Employees WHERE ManagerID IS NULL

--Problm 11: Find all mployees with a Salary more than 50000
SELECT FirstName, LastName, Salary FROM Employees WHERE Salary >= 50000
ORDER BY Salary DESC

--Problem 12: Find 5 best paid Employees
SELECT TOP(5) FirstName, LastName FROM Employees ORDER BY Salary DESC

--Problem 13: Find all employees except Marketing
SELECT FirstName, LastName FROM Employees WHERE DepartmentID <> 4

--Problem 14: Sort Employees table
SELECT * FROM Employees 
ORDER BY Salary DESC, 
FirstName ASC, 
LastName DESC, 
MiddleName ASC

--Problem 15: Create view Employees with salaries
CREATE VIEW V_EmployeesSalaries AS SELECT FirstName, LastName, Salary FROM Employees

--Problem 16: Create view Employees with job titles
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT_WS(' ', FirstName, ISNULL(NULLIF(MiddleName, ''), ''), LastName) AS [Full Name], JobTitle AS [Job Title]
FROM Employees

--Problem 17: Distinct job titles
SELECT DISTINCT JobTitle FROM Employees

--Problem 18: Find first 10 started Projects
SELECT TOP(10) * FROM Projects 
ORDER BY StartDate, Name

--Problem 19: Last 7 hired Employees
SELECT TOP(7) FirstName, LastName, HireDate FROM Employees 
ORDER BY HireDate DESC


-- Problem 20: Increase Salaries
UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID IN (
    SELECT DepartmentID
    FROM Departments
    WHERE Name IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
);

SELECT Salary
FROM Employees;
