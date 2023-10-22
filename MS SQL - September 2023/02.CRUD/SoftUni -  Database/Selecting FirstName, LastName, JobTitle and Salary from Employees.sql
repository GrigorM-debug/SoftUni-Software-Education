<<<<<<< HEAD
USE SoftUniSecondDb

-- Selecting FirstName, LastName and Salary from Employees. We must concatinate FirsName and LastName as FullName
SELECT CONCAT_WS(' ', FirstName, LastName) AS [Full Name],
    JobTitle,
    Salary
=======
USE SoftUniSecondDb

-- Selecting FirstName, LastName and Salary from Employees. We must concatinate FirsName and LastName as FullName
SELECT CONCAT_WS(' ', FirstName, LastName) AS [Full Name],
    JobTitle,
    Salary
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
FROM Employees