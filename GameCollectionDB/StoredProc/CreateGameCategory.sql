CREATE PROCEDURE [dbo].[CreateGameCategory]
	@gameTitle nvarchar(50),
	@gameReleaseDate datetime2(7),
	@gameDescription nvarchar(250),
	@categoryName nvarchar(50)
AS
BEGIN
	DECLARE @gameId int
	DECLARE @existingCategoryId int

	SELECT @gameId = IdGame FROM Games WHERE Title = @gameTitle

	IF @gameId IS NULL
	BEGIN
		INSERT INTO Games VALUES (@gameTitle, @gameReleaseDate, @gameDescription)
		SET @gameId = SCOPE_IDENTITY()
	END

	SELECT @existingCategoryId = IdCategory FROM Categories WHERE Name = @categoryName

	IF @existingCategoryId IS NULL
	BEGIN
		INSERT INTO Categories (Name) VALUES (@categoryName)
		SET @existingCategoryId = SCOPE_IDENTITY()
	END

	INSERT INTO GameCategory (GameId, CategoryId) VALUES (@gameId, @existingCategoryId)
END
RETURN 0
