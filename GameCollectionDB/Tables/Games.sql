﻿CREATE TABLE [dbo].[Games]
(
	[IdGame] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[ReleaseDate] DATETIME2(7),
	[Description] NVARCHAR(250),
)
