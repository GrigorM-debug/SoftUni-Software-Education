<<<<<<< HEAD
CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrighYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(2, 1) NOT NULL,
	[Notes] NVARCHAR(1000)
)


INSERT INTO [Directors] ([DirectorName], [Notes])
VALUES
    ('Christopher Nolan', 'Acclaimed director known for his work on Inception and The Dark Knight trilogy.'),
    ('Quentin Tarantino', 'Famous for Pulp Fiction and Kill Bill.'),
    ('Steven Spielberg', 'Director of classics like E.T. and Jurassic Park.');


INSERT INTO [Genres] ([GenreName], [Notes])
VALUES
    ('Action', 'Action-packed movies with intense sequences.'),
    ('Drama', 'Movies focused on character development and emotional narratives.'),
    ('Science Fiction', 'Movies set in futuristic or imaginative settings.');


INSERT INTO [Categories] ([CategoryName], [Notes])
VALUES
    ('Adventure', 'Exciting journeys and exploration.'),
    ('Romance', 'Love and romantic relationships.'),
    ('Horror', 'Frightening and suspenseful movies.');


INSERT INTO [Movies] ([Title], [DirectorId], [CopyrighYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
    ('Inception', 1, 2010, '02:28:00', 3, 1, 8.8, 'A mind-bending science fiction film.'),
    ('Pulp Fiction', 2, 1994, '02:34:00', 2, 2, 8.9, 'A cult classic with non-linear storytelling.'),
    ('Jurassic Park', 3, 1993, '02:07:00', 1, 3, 8.1, 'A thrilling adventure with dinosaurs.'),
    ('The Dark Knight', 1, 2008, '02:32:00', 1, 1, 9.0, 'Second installment of the Batman trilogy.'),
    ('Kill Bill: Vol. 1', 2, 2003, '01:51:00', 1, 1, 8.1, 'Action-packed revenge saga.');


=======
CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(1000)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrighYear] INT NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] DECIMAL(2, 1) NOT NULL,
	[Notes] NVARCHAR(1000)
)


INSERT INTO [Directors] ([DirectorName], [Notes])
VALUES
    ('Christopher Nolan', 'Acclaimed director known for his work on Inception and The Dark Knight trilogy.'),
    ('Quentin Tarantino', 'Famous for Pulp Fiction and Kill Bill.'),
    ('Steven Spielberg', 'Director of classics like E.T. and Jurassic Park.');


INSERT INTO [Genres] ([GenreName], [Notes])
VALUES
    ('Action', 'Action-packed movies with intense sequences.'),
    ('Drama', 'Movies focused on character development and emotional narratives.'),
    ('Science Fiction', 'Movies set in futuristic or imaginative settings.');


INSERT INTO [Categories] ([CategoryName], [Notes])
VALUES
    ('Adventure', 'Exciting journeys and exploration.'),
    ('Romance', 'Love and romantic relationships.'),
    ('Horror', 'Frightening and suspenseful movies.');


INSERT INTO [Movies] ([Title], [DirectorId], [CopyrighYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
    ('Inception', 1, 2010, '02:28:00', 3, 1, 8.8, 'A mind-bending science fiction film.'),
    ('Pulp Fiction', 2, 1994, '02:34:00', 2, 2, 8.9, 'A cult classic with non-linear storytelling.'),
    ('Jurassic Park', 3, 1993, '02:07:00', 1, 3, 8.1, 'A thrilling adventure with dinosaurs.'),
    ('The Dark Knight', 1, 2008, '02:32:00', 1, 1, 9.0, 'Second installment of the Batman trilogy.'),
    ('Kill Bill: Vol. 1', 2, 2003, '01:51:00', 1, 1, 8.1, 'Action-packed revenge saga.');


>>>>>>> f2e9dee17a76411a4b30b1c8ffa1c861b94a7951
