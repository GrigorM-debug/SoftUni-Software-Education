<<<<<<< HEAD


USE SoftUniSecondDb

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (TeacherID, Name, ManagerID)
VALUES
	(101, 'John', NULL),
	(102, 'Maya', 106),
	(103, 'Silvia', 106),
	(104, 'Ted', 105),
	(105, 'Mark', 101),
	(106, 'Greta', 101)
=======


USE SoftUniSecondDb

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (TeacherID, Name, ManagerID)
VALUES
	(101, 'John', NULL),
	(102, 'Maya', 106),
	(103, 'Silvia', 106),
	(104, 'Ted', 105),
	(105, 'Mark', 101),
	(106, 'Greta', 101)
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
