CREATE DATABASE [SoftUni Database]

USE [SoftUni Database]

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Address] (
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] VARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)

CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[MiddleName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[JobTitle] VARCHAR(30) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([id]) NOT NULL,
	[HireDate] DATE NOT NULL,
	[Salary] MONEY NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Address]([Id]) NOT NULL
)


INSERT INTO [Towns]
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO [Address] ([AddressText], [TownId])
VALUES
    ('123 Main Street', 1),
    ('456 Elm Avenue', 2),
    ('789 Oak Lane', 3),
	('Sezam', 4)


INSERT INTO [Departments]
	VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary], [AddressId]) 
	VALUES
	('Ivaylo', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-12-23', 3500.00, 5),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1,	'2004-02-02',	4000.00, 6),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-03-03', 525.25, 7),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2003-09-09', 3000.00, 8),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2015-01-01', 599.88, 8)


SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

SELECT * FROM [Towns]
ORDER BY [Name] ASC

SELECT * FROM [Departments]
ORDER BY [Name] ASC

SELECT * FROM [Employees]
ORDER BY [Salary] DESC


SELECT [Name] FROM [Towns]
ORDER BY [Name] ASC
SELECT [Name] FROM [Departments]
ORDER BY [Name] ASC
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY [Salary] DESC

UPDATE [Employees]
SET [Salary] = [Salary] * 1.10
SELECT [Salary] FROM [Employees]
