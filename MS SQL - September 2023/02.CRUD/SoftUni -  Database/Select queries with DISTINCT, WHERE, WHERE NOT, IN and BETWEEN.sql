USE SoftUniSecondDb

--Using DISTINCT to eliminate duplicate results
SELECT DISTINCT DepartmentID, ManagerID FROM Employees

--Selecting LastName for Employeers with Salary larger than 22222
SELECT LastName, Salary FROM Employees
WHERE Salary >= 22222

--Selecting FirstName and LastName from Employees where manager id is not 3 or 4
SELECT FirstName, LastName FROM Employees
WHERE NOT (ManagerID = 3 OR ManagerID = 4)

--Selecting FirstName, LastName and ManagerId from Employees where ManagerId is 100, 3 or 16
SELECT FirstName, LastName, ManagerId FROM Employees
WHERE ManagerID IN (100, 3, 16)

--Selecting FirstName, LastName and Salary from Employees where Salary is between 1000 and 20000
SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary BETWEEN 1000 AND 20000

--Selecting everything from Employees where MiddleName is NULL
SELECT * FROM Employees WHERE MiddleName IS NULL