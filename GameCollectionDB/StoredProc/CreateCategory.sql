CREATE PROCEDURE [dbo].[CreateCategory]
	@categoryName varchar(50)
AS
	DECLARE @categoryId int

	SELECT @categoryId = IdCategory FROM Categories WHERE LOWER(Name) LIKE LOWER(@categoryName)

	IF @categoryId IS NULL
	BEGIN
		INSERT INTO Categories VALUES (@categoryName)
	END

RETURN 0
