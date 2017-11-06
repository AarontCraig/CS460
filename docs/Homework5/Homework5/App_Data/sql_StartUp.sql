/*Create the table with all the values, and all required*/
CREATE TABLE dbo.Users
(
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[DriversLicense] INT NOT NULL,
    [FirstName] NVARCHAR(64) NOT NULL, 
    [MiddleName] NVARCHAR(128) NOT NULL, 
    [LastName] NVARCHAR(128) NOT NULL, 
	[DOB] DateTime NOT NULL, 
	[UserAddress] NVARCHAR(128) NOT NULL,
    [City] NVARCHAR(128) NOT NULL, 
    [UserState] NVARCHAR(128) NOT NULL, 
    [ZIP] INT NOT NULL,
	[County] NVARCHAR(128) NOT NULL,
	[UpdateVoter] INT NOT NULL,
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED (ID)
);
/*Put 5 users into the DB, to test it out */
INSERT INTO dbo.Users VALUES
	('73233', 'Bobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('34234', 'gobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('11123', 'lobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('53221', 'cobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('92443', 'xobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1');

GO