CREATE DATABASE MovieCatalog;
GO

USE MovieCatalog
GO

CREATE TABLE Genres (
	GenreID int identity(1,1) not null primary key,
	GenreName varchar(20) not null
)
GO

CREATE TABLE Movies (
	MovieID int identity(1,1) not null primary key,
	Title nvarchar(30) not null,
	ReleaseYear int null,
	GenreID int not null,
	Foreign Key (GenreID) References Genres(GenreID)
)
GO

CREATE TABLE Actors (
	ActorID int identity (1,1) not null primary key,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	DateOfBirth date null,
)
GO

CREATE TABLE MovieActors (
	MovieID int not null,
	ActorID int not null,
	PRIMARY KEY (ActorID, MovieID),
	FOREIGN KEY (ActorID) References Actors(ActorID),
	FOREIGN KEY (MovieID) References Movies(MovieID)
)
GO

INSERT INTO Genres (GenreName)
VALUES ('Comedy'), --1
('Horror'), --2 
('Action'), --3 
('Romance'), -- 4
('Drama') -- 5;

INSERT INTO Actors (FirstName, LastName, DateOfBirth)
VALUES ('Bill', 'Murray', '9/21/1950'), -- 1
('John', 'Candy', '10/31/1950'),  -- 2
('Richard', 'Gere', '8/31/1949'), -- 3
('Julia', 'Roberts', '10/28/1967'), -- 4
('Al', 'Pacino', '4/25/1940'), --5 
('Dan', 'Aykroyd', '7/1/1952'),-- 6
('Keanu', 'Reeves', '9/2/1964'); -- 7

INSERT INTO Movies (Title, ReleaseYear, GenreID)
VALUES ('Stripes', 1981, 1), -- 1
('Devil''s Advocate', 1997, 2), -- 2
('Pretty Woman', 1990, 4), -- 3
('Ghostbusters', 1984, 1) -- 4

INSERT INTO MovieActors (MovieID, ActorID)
VALUES 
	(1,1), -- Stripes Bill Murray
	(1,2), -- Stripes John Candy
	(2,5), -- Devil's Advocate Al Pacino
	(2,7), -- Devil's Advocate Keanu Reeves
	(3,3),
	(3,4),
	(4,1),
	(4,6)



