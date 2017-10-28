CREATE TABLE Users
(
	[ID] INT NOT NULL,
	[DriversLIcense] INT NOT NULL,
    [FirstName] NVARCHAR(64) NOT NULL, 
    [MiddleName] NVARCHAR(128) NOT NULL, 
    [LastName] NVARCHAR(128) NOT NULL, 
	[DOB] DateTime NOT NULL, 
	[UserAddress] NVARCHAR(128) NOT NULL,
    [City] NVARCHAR(128) NOT NULL, 
    [UserState] NVARCHAR(128) NOT NULL, 
    [ZIP] INT NOT NULL,
	[County] NVARCHAR NOT NULL,
	[UpdateVoter] INT NOT NULL,
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO Users (DriversLicense, [FirstName], [MiddleName], [LastName], [DOB], [UserAddress], [City], [UserState], [ZIP], [County], [UpdateVoter]) VALUES
	('73233', 'Bobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('34234', 'gobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('11123', 'lobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('53221', 'cobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('92443', 'xobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1');

GO