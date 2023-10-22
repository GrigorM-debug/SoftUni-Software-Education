<<<<<<< HEAD
--Problem 01: Employee Address
SELECT
	TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--Problem 02: Addresses with Towns
SELECT 
	TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Problem 03: Sales Employee
SELECT 
	e.EmployeeID, e.FirstName, e.LastName, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 04: Employee Departments
SELECT 
	TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--Problem 05: Employees Without Projects
SELECT 
	TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ProjectID IS NULL
ORDER BY e.EmployeeID

--Probelm 06: Employees Hired After
SELECT 
	e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01 00:00:00' AND d.Name IN('Sales', 'Finance')
ORDER BY e.HireDate ASC

--Problem 07: Employees with Project
SELECT
	TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects as p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
ORDER BY e.EmployeeID

--Problem 08: Employee 24
SELECT
	e.EmployeeID, e.FirstName, 
	CASE
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
	END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--Problem 09: Employee Manager
SELECT
	e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

--Problem 10: Employees Summary
SELECT
	TOP (50) e.EmployeeID, CONCAT_WS(' ', e.FirstName, e.LastName) AS [EmployeeName], CONCAT_WS(' ', m.FirstName, m.LastName) AS [ManagerName], d.Name AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--Problem 11: Min Average Salary
SELECT 
	TOP (1) AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
=======
--Problem 01: Employee Address
SELECT
	TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--Problem 02: Addresses with Towns
SELECT 
	TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--Problem 03: Sales Employee
SELECT 
	e.EmployeeID, e.FirstName, e.LastName, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 04: Employee Departments
SELECT 
	TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--Problem 05: Employees Without Projects
SELECT 
	TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ProjectID IS NULL
ORDER BY e.EmployeeID

--Probelm 06: Employees Hired After
SELECT 
	e.FirstName, e.LastName, e.HireDate, d.[Name] AS [DeptName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01 00:00:00' AND d.Name IN('Sales', 'Finance')
ORDER BY e.HireDate ASC

--Problem 07: Employees with Project
SELECT
	TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects as p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
ORDER BY e.EmployeeID

--Problem 08: Employee 24
SELECT
	e.EmployeeID, e.FirstName, 
	CASE
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
	END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects as ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--Problem 09: Employee Manager
SELECT
	e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3, 7)
ORDER BY e.EmployeeID

--Problem 10: Employees Summary
SELECT
	TOP (50) e.EmployeeID, CONCAT_WS(' ', e.FirstName, e.LastName) AS [EmployeeName], CONCAT_WS(' ', m.FirstName, m.LastName) AS [ManagerName], d.Name AS [DepartmentName]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--Problem 11: Min Average Salary
SELECT 
	TOP (1) AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
ORDER BY MinAverageSalary