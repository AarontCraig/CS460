CREATE TABLE dbo.Users
(
	[Id] INT NOT NULL PRIMARY KEY, 
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
)

INSERT INTO dbo.Users (ID, FirstName, MiddleName, LastName, DOB, UserAddress, City, UserState, ZIP, County, UpdateVoter) VALUES
	('23432', 'Bobby', 'Lee', 'Jones', '2004-05-23 14:25:10.487', 'Some # some street', 'Salem', 'Oregon', '97302', '1'),
	('32452', 'Julie', 'Lo', 'Mine', '2005-05-23 14:25:10.487', 'Some # some street', 'Monmoth', 'Oregon', '97302', '0'),
	('12346', 'Sam', 'Been', 'Yut', '2006-05-23 14:25:10.487', 'Some # some street', 'Aumsville', 'Oregon', '97302', '1'),
	('86645', 'Drit', 'Stoa', 'Fai', '2007-05-23 14:25:10.487', 'Some # some street', 'Eugene', 'Oregon', '97302', '0'),
	('96434', 'Kile', 'Ju', 'John', '2008-05-23 14:25:10.487', 'Some # some street', 'Boring', 'Oregon', '97302', '1');

GO