CREATE PROCEDURE MovieGetAll 
AS

SELECT MovieID, Title, m.GenreID, GenreName, ReleaseYear
FROM Movies m 
	INNER JOIN Genres g ON m.GenreID = g.GenreID
ORDER BY m.Title
GO

CREATE PROCEDURE GenreGetAll
AS

SELECT GenreID, GenreName
FROM Genres
ORDER BY GenreName
GO

CREATE PROCEDURE ActorGetInMovie (
	@MovieID int
) AS

SELECT ActorID, FirstName, LastName, DateOfBirth
FROM Actors 
WHERE ActorID IN (SELECT ActorID FROM MovieActors WHERE MovieID = @MovieID);
GO

CREATE PROCEDURE ActorGetNotInMovie (
	@MovieID int
) AS

SELECT ActorID, FirstName, LastName, DateOfBirth
FROM Actors 
WHERE ActorID NOT IN (SELECT ActorID FROM MovieActors WHERE MovieID = @MovieID);
GO

CREATE PROCEDURE MovieGet (
	@MovieID int
) AS

SELECT MovieID, Title, GenreID, ReleaseYear
FROM Movies
WHERE MovieID = @MovieID
GO

CREATE PROCEDURE MovieUpdate (
	@MovieID int,
	@Title nvarchar(30),
	@ReleaseYear int,
	@GenreId int
) AS

UPDATE Movies SET
	Title = @Title,
	ReleaseYear = @ReleaseYear,
	GenreID = @GenreId
WHERE MovieID = @MovieID;
GO

CREATE PROCEDURE MovieDeleteActor (
	@MovieID int,
	@ActorID int
) AS

DELETE FROM MovieActors WHERE MovieID = @MovieID AND ActorID = @ActorID
GO

CREATE PROCEDURE MovieInsertActor (
	@MovieID int,
	@ActorID int
) AS

INSERT INTO MovieActors (MovieID, ActorID) VALUES (@MovieID, @ActorID)
GO
