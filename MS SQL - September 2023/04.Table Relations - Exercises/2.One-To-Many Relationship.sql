<<<<<<< HEAD
USE SoftUniSecondDb

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	EstablishedOn DATETIME2
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	Name NVARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models (Name, ManufacturerID)
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
=======
USE SoftUniSecondDb

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	EstablishedOn DATETIME2
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	Name NVARCHAR(50) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models (Name, ManufacturerID)
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
	('Nova', 3)