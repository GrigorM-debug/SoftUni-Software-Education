<<<<<<< HEAD
Use SoftUniSecondDb

SELECT 
    CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Име],
    Salary AS [Заплата],
    d.[Name] AS [Отдел],
    a.AddressText AS [Адрес],
    t.[Name] AS [Град]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE e.[DepartmentID] = 1
ORDER BY Salary ASC

=======
Use SoftUniSecondDb

SELECT 
    CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Име],
    Salary AS [Заплата],
    d.[Name] AS [Отдел],
    a.AddressText AS [Адрес],
    t.[Name] AS [Град]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE e.[DepartmentID] = 1
ORDER BY Salary ASC

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
