-- create database with name RobotsManagement if not exist 

CREATE TABLE TypeModel 
(
	Id			INT PRIMARY KEY IDENTITY(1,1),
	Name		NVARCHAR(25),
	Description	NVARCHAR(50)
)
GO

CREATE TABLE RobotType
(
	Id			INT PRIMARY KEY IDENTITY(1,1),
	ModelId		INT FOREIGN KEY REFERENCES TypeModel(Id),
	Name		NVARCHAR(25),
	Description	NVARCHAR(50)
)
GO

CREATE TABLE [User](
	Id				INT PRIMARY KEY IDENTITY(1,1),
	UserSystemId	UNIQUEIDENTIFIER,
	FirstName		NVARCHAR(30),
	LastName		NVARCHAR(30),
	Email			NVARCHAR(50),
	Password		NVARCHAR(MAX),
	AddedDate		DATETIME
)
GO

CREATE TABLE Robot
(
	Id			INT PRIMARY KEY IDENTITY(1,1),
	Name		NVARCHAR(50),
	UserId		INT FOREIGN KEY REFERENCES [User](Id),
	RobotTypeId	INT FOREIGN KEY REFERENCES RobotType(Id)
)
GO