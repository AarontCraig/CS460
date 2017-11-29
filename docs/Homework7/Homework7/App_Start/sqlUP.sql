CREATE TABLE dbo.Queries (
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[SearchQuery] varchar(255) NOT NULL,
	[SearchDate] DateTime NOT NULL,
	[SearchIP] varchar(255),
	[SearchBrowser] varchar(255),
	CONSTRAINT [PK_dbo.Queries] PRIMARY KEY CLUSTERED (ID)
);