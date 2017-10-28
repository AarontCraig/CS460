CREATE TABLE Users
(
	[ID] INT NOT NULL,
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
	CONSTRAINT PK_User PRIMARY KEY (ID)
);

INSERT INTO Users VALUES
	('1', '73233', 'Bobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('2', '34234', 'gobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('3', '11123', 'lobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('4', '53221', 'cobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1'),
	('5', '92443', 'xobby', 'Dyson', 'Sori', '10-12-12 12:00:00', 'Some street #', 'Salem', 'OR', '97302', 'Marion', '1');

GO