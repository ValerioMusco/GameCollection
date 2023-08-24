/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE GameCollectionDB
GO

INSERT INTO Categories VALUES ('FPS');
INSERT INTO Categories VALUES ('TPS');
INSERT INTO Categories VALUES ('RPG');
INSERT INTO Categories VALUES ('MMO');
INSERT INTO Categories VALUES ('RTS');
INSERT INTO Categories VALUES ('Action');
INSERT INTO Categories VALUES ('Simulation');
INSERT INTO Categories VALUES ('SandBox');
INSERT INTO Categories VALUES ('Adventure');
INSERT INTO Categories VALUES ('Sports');

INSERT INTO Games (Title, ReleaseDate, Description)
VALUES
    ('Call of Duty: Modern Warfare', '2020-10-25', 'A popular FPS game'),
    ('The Witcher 3: Wild Hunt', '2015-05-19', 'An open-world RPG'),
    ('Minecraft', '2011-11-18', 'A sandbox game about building and survival'),
    ('FIFA 22', '2021-10-01', 'A soccer sports game'),
    ('Grand Theft Auto V', '2013-09-17', 'An open-world action-adventure game');

INSERT INTO GameCategory (GameId, CategoryId)
VALUES
    (1, 1),
    (1, 6);

INSERT INTO GameCategory (GameId, CategoryId)
VALUES
    (2, 3),
    (2, 9);

INSERT INTO GameCategory (GameId, CategoryId)
VALUES
    (3, 7),
    (3, 8);

INSERT INTO GameCategory (GameId, CategoryId)
VALUES
    (4, 10);

INSERT INTO GameCategory (GameId, CategoryId)
VALUES
    (5, 6),
    (5, 8);