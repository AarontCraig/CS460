﻿CREATE TABLE dbo.ARTIST (
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[NAME] VARCHAR(255) NOT NULL,
	[DOB] DATE NOT NULL,
	[BIRTHCITY] VARCHAR(255) NOT NULL
);

CREATE TABLE dbo.ARTWORK (
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[TITLE] VARCHAR(255) NOT NULL,
	[ARTIST] INT FOREIGN KEY REFERENCES dbo.ARTIST(ID) NOT NULL
);

CREATE TABLE dbo.GENRE (
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[NAME] VARCHAR(255) NOT NULL
);

CREATE TABLE dbo.CLASSIFICATION (
	[ID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[ARTWORK] INT FOREIGN KEY REFERENCES dbo.ARTWORK(ID) NOT NULL,
	[GENRE] INT FOREIGN KEY REFERENCES dbo.GENRE(ID) NOT NULL
);

INSERT INTO dbo.ARTIST VALUES
	('M.C. Escher', '06/17/1898', 'Leeuwarden, Netherlands'),
	('Leonardo Da Vinci', '05/2/1519', 'Vinci, Italy'),
	('Hatip Mehmed Efendi', '11/18/1680', 'Unkown'),
	('Salvador Dali', '05/11/1904', 'Figueres, Spain');
	
INSERT INTO dbo.ARTWORK VALUES
	('Circle Limit III', '1'),
	('Twon Tree', '1'),
	('Mona Lisa', '2'),
	('The Vitruvian Man', '2'),
	('Ebru', '3'),
	('Honey Is Sweeter Than Blood', '4');

INSERT INTO dbo.GENRE VALUES 
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance');

INSERT INTO dbo.CLASSIFICATION VALUES
	('1', '1'),
	('2', '1'),
	('2', '2'),
	('3', '3'),
	('3', '4'),
	('4', '4'),
	('5', '1'),
	('6', '2');

drop table dbo.__MigrationHistory;
drop table dbo.ARTIST;
drop table dbo.ARTWORK;
drop table dbo.CLASSIFICATION;
drop table dbo.GENRE;