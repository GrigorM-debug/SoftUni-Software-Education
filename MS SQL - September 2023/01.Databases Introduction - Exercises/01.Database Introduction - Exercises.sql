<<<<<<< HEAD
-- Problem 01 - Create Database (Minions)
CREATE DATABASE Minions
GO

USE [Minions]

--Problem 02: Create tables (Minions and Towns)
CREATE TABLE Minions (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE Towns (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

--Problem 03: Alter minions table
ALTER TABLE [Minions] 
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

--Problem 04: Insert records in both tables
INSERT INTO [Towns] ([Id], [Name])
	VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

ALTER TABLE [Minions]
ALTER COLUMN [AGE] INT

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId])
	VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

--Problem 05: Truncate table Minions
TRUNCATE TABLE [Minions]

--Problem 06: Drop all tables
DROP TABLE [Minions]
DROP TABLE [Towns]

--Problem 07: Create table People
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[BirthDate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [BirthDate])
     VALUES
('Pesho', 1.65, 70.6, 'm', '2003-01-07'),
('Gosho', NULL, NULL, 'm', '1977-08-02'),
('Maria', 1.74, 55.6, 'f', '1949-10-24'),
('ToshoKykata', 1.70, 80, 'm', '1969-06-09'),
('GlavniaIliev', 1.30, 40, 'm', '1969-06-09')

--Problem 08: Create table Users
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] DATE,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES
	('GoshoTuhlata', 'gosho222', NULL, '2022-11-12', 0),
	('Toshko', '1212', NULL, '2023-11-11', 1),
	('Pesho','pesho123', NULL, '2003-01-07', 0),
	('Gosho', 'gosho11' , NULL, '1977-08-02', 1),
	('Maria', 'password' , NULL, '1949-10-24', 0)


TRUNCATE TABLE Users

--Problem 09: Change primary key
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE  

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07808BA82A

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)


--Problem 10: Add check constraint to Users table

--First I need to update some passwords in Users table because they are less than 5 symbols 
UPDATE [Users]
SET [Password] = 'Iamthemoststupidperson'
WHERE [Id] = 2

ALTER TABLE [Users]
ADD CONSTRAINT Check_PasswordLenght CHECK (LEN([Password]) >= 5)


--Problem 11: Set default value of a field
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

--Problem 12: Set unique field
ALTER TABLE [Users]
DROP CONSTRAINT [PK_Users]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users] PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [UC_LastLoginTime] UNIQUE ([Username])

ALTER TABLE [Users]
ADD CONSTRAINT [Check_UsernameLength] CHECK (LEN([Username]) >= 3)

=======
-- Problem 01 - Create Database (Minions)
CREATE DATABASE Minions
GO

USE [Minions]

--Problem 02: Create tables (Minions and Towns)
CREATE TABLE Minions (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

CREATE TABLE Towns (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

--Problem 03: Alter minions table
ALTER TABLE [Minions] 
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL

--Problem 04: Insert records in both tables
INSERT INTO [Towns] ([Id], [Name])
	VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

ALTER TABLE [Minions]
ALTER COLUMN [AGE] INT

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId])
	VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

--Problem 05: Truncate table Minions
TRUNCATE TABLE [Minions]

--Problem 06: Drop all tables
DROP TABLE [Minions]
DROP TABLE [Towns]

--Problem 07: Create table People
CREATE TABLE [People] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] = 'f'),
	[BirthDate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [BirthDate])
     VALUES
('Pesho', 1.65, 70.6, 'm', '2003-01-07'),
('Gosho', NULL, NULL, 'm', '1977-08-02'),
('Maria', 1.74, 55.6, 'f', '1949-10-24'),
('ToshoKykata', 1.70, 80, 'm', '1969-06-09'),
('GlavniaIliev', 1.30, 40, 'm', '1969-06-09')

--Problem 08: Create table Users
CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] DATE,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES
	('GoshoTuhlata', 'gosho222', NULL, '2022-11-12', 0),
	('Toshko', '1212', NULL, '2023-11-11', 1),
	('Pesho','pesho123', NULL, '2003-01-07', 0),
	('Gosho', 'gosho11' , NULL, '1977-08-02', 1),
	('Maria', 'password' , NULL, '1949-10-24', 0)


TRUNCATE TABLE Users

--Problem 09: Change primary key
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE  

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07808BA82A

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)


--Problem 10: Add check constraint to Users table

--First I need to update some passwords in Users table because they are less than 5 symbols 
UPDATE [Users]
SET [Password] = 'Iamthemoststupidperson'
WHERE [Id] = 2

ALTER TABLE [Users]
ADD CONSTRAINT Check_PasswordLenght CHECK (LEN([Password]) >= 5)


--Problem 11: Set default value of a field
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime] DEFAULT GETDATE() FOR [LastLoginTime]

--Problem 12: Set unique field
ALTER TABLE [Users]
DROP CONSTRAINT [PK_Users]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_Users] PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [UC_LastLoginTime] UNIQUE ([Username])

ALTER TABLE [Users]
ADD CONSTRAINT [Check_UsernameLength] CHECK (LEN([Username]) >= 3)

>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
