CREATE TABLE [dbo].[GameCategory]
(
	[GameId] INT,
	[CategoryId] INT,
	PRIMARY KEY([GameId], CategoryId),
	FOREIGN KEY([GameId]) REFERENCES Games(IdGame),
	FOREIGN KEY(CategoryId) REFERENCES Categories(IdCategory)
)
