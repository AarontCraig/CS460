﻿CREATE TABLE dbo.ARTIST (
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[NAME] VARCHAR(255) NOT NULL,
	[DOB] DATE NOT NULL,
	[BIRTHCITY] VARCHAR(255) NOT NULL,
	CONSTRAINT [PK_dbo.ARTIST] PRIMARY KEY CLUSTERED (ID)
);

CREATE TABLE dbo.ARTWORK (
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[TITLE] VARCHAR(255) NOT NULL,
	[ARTIST] INT FOREIGN KEY REFERENCES dbo.ARTIST(ID),
	CONSTRAINT [PK_dbo.ARTWORK] PRIMARY KEY CLUSTERED (ID)
);

CREATE TABLE dbo.GENRE (
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[NAME] VARCHAR(255) NOT NULL,
	CONSTRAINT [PK_dbo.GENRE] PRIMARY KEY CLUSTERED (ID)
);

CREATE TABLE dbo.CLASSIFICATION (
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[ARTWORK] INT FOREIGN KEY REFERENCES dbo.ARTWORK(ID),
	[GENRE] INT FOREIGN KEY REFERENCES dbo.GENRE(ID),
	CONSTRAINT [PK_dbo.CLASSIFICATION] PRIMARY KEY CLUSTERED (ID)
);