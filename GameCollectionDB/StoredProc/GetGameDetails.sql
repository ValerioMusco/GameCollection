CREATE PROCEDURE [dbo].[GetGameDetails]
	@gameName nvarchar(50)
AS
	SELECT g.IdGame, g.Title, g.ReleaseDate, g.[Description],
       STRING_AGG(c.[Name], ',') AS CategoryNames
	FROM Games g
		JOIN GameCategory gc ON g.IdGame = gc.GameId
		JOIN Categories c ON c.IdCategory = gc.CategoryId
	WHERE LOWER(g.Title) LIKE LOWER(@gameName)
	GROUP BY g.IdGame, g.Title, g.ReleaseDate, g.[Description];
RETURN 0
