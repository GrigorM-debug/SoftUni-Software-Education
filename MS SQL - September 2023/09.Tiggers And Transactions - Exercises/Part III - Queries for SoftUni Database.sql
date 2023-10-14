--Problem 08: Employees with Three Projects
CREATE OR ALTER PROCEDURE usp_AssignProject(@employeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
    IF((SELECT COUNT(ProjectID) FROM EmployeesProjects WHERE EmployeeID = @employeeId) >=3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
        ROLLBACK
    END

    INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
        VALUES(@employeeId, @projectID)
COMMIT

EXEC usp_AssignProject 1, 2     


--Problem 09: Delete Employees
CREATE TABLE Deleted_Employees(
    EmployeeId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50) NOT NULL,
    JobTitle VARCHAR(30) NOT NULL,
    DepartmentId INT FOREIGN KEY REFERENCES Departments(DepartmentID) NOT NULL,
    Salary MONEY NOT NULL
)

CREATE TRIGGER tr_AddEntityToDeletedEmployeesTable
ON Employees FOR DELETE
AS
INSERT INTO Deleted_Employees
	SELECT		
		FirstName,
		LastName,
		MiddleName,
		JobTitle,
		DepartmentID,
		Salary
	FROM deleted