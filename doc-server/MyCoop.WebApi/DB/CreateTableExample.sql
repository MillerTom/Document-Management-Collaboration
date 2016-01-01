CREATE TABLE Incidents
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1, 1),
	Name nvarchar(MAX) NOT NULL,
	Lat float NOT NULL CHECK (Lat > 0),
	Lng float NOT NULL CHECK (Lng > 0),
	[Address] nvarchar(MAX) NOT NULL,
	[Type] int NOT NULL CHECK([Type] IN (1,2,3)),
	[Priority] int NOT NULL,
	FacilityType int NOT NULL,
	StartTime datetime2(7) NOT NULL,
	Duration bigint NOT NULL,
	[Description] nvarchar(MAX) NOT NULL,
)