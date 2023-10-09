--Problem 13: Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--Problem 14: Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimalSalary
FROM Employees
WHERE DepartmentID IN(2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--Problem 15: Employees average salaries
SELECT * INTO EmployeesSecond
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesSecond
WHERE ManagerID = 42

UPDATE EmployeesSecond
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesSecond
GROUP BY DepartmentID

--Problem 16: Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING Max(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17: Employees Count Salaries
SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--Problem 18: 3rd HighestSalary
SELECT DepartmentID, Salary
FROM (
	SELECT Salary, DepartmentID,
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
	GROUP BY DepartmentID, Salary) AS subq
WHERE subq.SalaryRank = 3

--Problem 19: Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentId
FROM Employees AS e1
WHERE Salary > (
			SELECT AVG(Salary) FROM Employees AS e2
			WHERE e2.DepartmentID = e1.DepartmentID
			GROUP BY DepartmentID
			)
ORDER BY DepartmentID
