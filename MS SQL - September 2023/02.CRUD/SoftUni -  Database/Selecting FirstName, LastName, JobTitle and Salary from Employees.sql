USE SoftUniSecondDb

-- Selecting FirstName, LastName and Salary from Employees. We must concatinate FirsName and LastName as FullName
SELECT CONCAT_WS(' ', FirstName, LastName) AS [Full Name],
    JobTitle,
    Salary
FROM Employees