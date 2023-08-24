CREATE PROCEDURE [dbo].[GetGame]
	@gameCategory nvarchar(50)
AS
	SELECT DISTINCT g.Title FROM Games g
				 JOIN GameCategory gc on g.IdGame = gc.GameId
				 JOIN Categories c on gc.CategoryId = c.IdCategory
	WHERE c.Name like CONCAT_WS('', @gameCategory, '%')
RETURN 0
